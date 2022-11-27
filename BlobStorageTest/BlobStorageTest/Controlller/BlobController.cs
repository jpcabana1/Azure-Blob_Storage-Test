using BlobStorageTest.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlobStorageTest.Controlller;

[Route("/api/[controller]")]
public class BlobController : ControllerBase
{
    private readonly IBlobService _service;
    public BlobController(IBlobService service)
    {
        _service = service;
    }
    [HttpPost("upload")]
    public async Task<IActionResult> Upload(IFormFile file)
    {
        try
        {
            var res = await _service.Upload(file);
            return Ok(new { Value = res });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

    [HttpGet("dowload")]
    public async Task<IActionResult> Download(string blobName)
    {
        try
        {
            var res = await _service.Download(blobName);
            return Ok(res);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }
}

