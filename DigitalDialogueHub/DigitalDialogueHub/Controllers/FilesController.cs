using DigitalDialogueHub.DTOs;
using DigitalDialogueHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using File = DigitalDialogueHub.Models.File;

namespace DigitalDialogueHub.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class FilesController : ControllerBase
{
    private readonly DigitalDialogueHubContext _context;
    public FilesController(DigitalDialogueHubContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<File>>> GetAll() => await _context.Files.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<File>> Get(int id)
    {
        var file = await _context.Files.FindAsync(id);
        return file == null ? NotFound() : file;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] FileDto fileDto)
    {
        var user = await _context.Users.FindAsync(fileDto.UploadedBy);
        if (user == null)
        {
            return BadRequest($"Korisnik sa ID {fileDto.UploadedBy} ne postoji.");
        }

        var discussion = await _context.Discussions.FindAsync(fileDto.DiscussionId);
        if (discussion == null)
        {
            return BadRequest($"Diskusija sa ID {fileDto.DiscussionId} ne postoji.");
        }

        var file = new File
        {
            FileName = fileDto.FileName,
            FileType = fileDto.FileType,
            FilePath = fileDto.FilePath,
            UploadedAt = fileDto.UploadedAt,
            UploadedBy = fileDto.UploadedBy,
            DiscussionId = fileDto.DiscussionId,
            IsDeleted = fileDto.IsDeleted
        };

        _context.Files.Add(file);
        await _context.SaveChangesAsync();

        return Ok(file);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] File file)
    {
        if (id != file.Id)
            return BadRequest("ID fajla se ne poklapa.");

        var existingFile = await _context.Files.FindAsync(id);
        if (existingFile == null)
            return NotFound($"Fajl sa ID {id} nije pronađen.");

        
        var userExists = await _context.Users.AnyAsync(u => u.Id == file.UploadedBy);
        if (!userExists)
            return BadRequest($"Korisnik sa ID {file.UploadedBy} ne postoji.");

        
        var discussionExists = await _context.Discussions.AnyAsync(d => d.Id == file.DiscussionId);
        if (!discussionExists)
            return BadRequest($"Diskusija sa ID {file.DiscussionId} ne postoji.");

        
        existingFile.FileName = file.FileName;
        existingFile.FileType = file.FileType;
        existingFile.FilePath = file.FilePath;
        existingFile.UploadedAt = file.UploadedAt;
        existingFile.UploadedBy = file.UploadedBy;
        existingFile.DiscussionId = file.DiscussionId;
        existingFile.IsDeleted = file.IsDeleted;

        await _context.SaveChangesAsync();
        return Ok(existingFile);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var file = await _context.Files.FindAsync(id);
        if (file == null) return NotFound();
        _context.Files.Remove(file);
        await _context.SaveChangesAsync();
        return NoContent();
    }
    [HttpPost]
    [DisableRequestSizeLimit] // po potrebi postavi limit u appsettings ako želiš
    public async Task<IActionResult> Upload([FromForm] IFormFile file, [FromForm] int uploadedBy, [FromForm] int discussionId)
    {
        if (file == null || file.Length == 0)
            return BadRequest("Nijedan fajl nije dostavljen.");

        var userExists = await _context.Users.AnyAsync(u => u.Id == uploadedBy);
        var discussionExists = await _context.Discussions.AnyAsync(d => d.Id == discussionId);
        if (!userExists || !discussionExists)
            return BadRequest("Neispravan UploadedBy ili DiscussionId.");

        var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
        if (!Directory.Exists(uploadsFolder))
            Directory.CreateDirectory(uploadsFolder);

        var uniqueFileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        var fileRecord = new File
        {
            FileName = file.FileName,
            FileType = file.ContentType,
            FilePath = $"/uploads/{uniqueFileName}", // relativna putanja
            UploadedAt = DateTime.UtcNow,
            UploadedBy = uploadedBy,
            DiscussionId = discussionId,
            IsDeleted = false
        };

        _context.Files.Add(fileRecord);
        await _context.SaveChangesAsync();

        return Ok(fileRecord);
    }

}
