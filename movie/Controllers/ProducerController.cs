using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class ProducerController: ControllerBase{

    private static MovieDbContext _movieDbContext;

    public ProducerController(MovieDbContext movieDbContext){
        _movieDbContext= movieDbContext;
    }

    [HttpGet]
    public async Task<IActionResult> Get(){
        var producers = await _movieDbContext.Producers.ToListAsync();
        return Ok(producers);
    }

    [HttpGet("{Id:int}")]

    public async Task<IActionResult> Get(int Id){
        var producer = await _movieDbContext.Producers.FirstOrDefaultAsync(x=>x.Id==Id);
        if (producer == null) return BadRequest("bad request");
        return Ok(producer);

    }

    [HttpPost]

    public async Task<IActionResult> Post(Producer producer){
        await _movieDbContext.Producers.AddAsync(producer);
        await _movieDbContext.SaveChangesAsync();

        return CreatedAtAction("Get",producer.Id,producer);

    }

    [HttpPatch]

    public async Task<IActionResult> Patch(int Id,string CompanyEmail){
        var producer = await _movieDbContext.Producers.FirstOrDefaultAsync(x=>x.Id==Id);
        if (producer== null) return BadRequest("bad request");
        producer.CompanyEmail = CompanyEmail;
        await _movieDbContext.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete]

    public async Task<IActionResult> Delete(int Id){
        var producer = await _movieDbContext.Producers.FirstOrDefaultAsync(x=>x.Id==Id);
        if (producer==null) return BadRequest("bad request");
        _movieDbContext.Producers.Remove(producer);
        await _movieDbContext.SaveChangesAsync();

        return NoContent();
    }



}