using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class MoviesController: ControllerBase{

    private static MovieDbContext? _movieDbContext;

    public MoviesController(MovieDbContext movieDbContext){
        _movieDbContext = movieDbContext;
    }

    // public static List<Movie> movies  = new List<Movie>(){
    //     new Movie(){
    //         ID = 1,
    //         Name = "The High Table",
    //         Country= "Russia",
    //         Description = "All are killers"

    //     }
    //     ,
    //      new Movie(){
    //         ID =2,
    //         Name = "The Red devils",
    //         Country= "Englad",
    //         Description = "They all are Evils"
            
    //     },
    //      new Movie(){
    //         ID = 4,
    //         Name = "The Mandalorian",
    //         Country= "Mongola",
    //         Description = "All of the ride the mythorus"
            
    //     }
    //     ,
    //      new Movie(){
    //         ID = 5,
    //         Name = "The wasps of the multiverse",
    //         Country= "USA",
    //         Description = "All can be Ants"
            
    //     },
    //      new Movie(){
    //         ID = 7,
    //         Name = "The Kingsman",
    //         Country= "Germany",
    //         Description = "Relationship doesn't work there"
            
    //     }
    // };

    [HttpGet]
    public async Task<IActionResult> Get(){

        var movies = await _movieDbContext!.Movies.ToListAsync();
        
        return Ok(movies);
    }

    [HttpGet("{Id:int}")]
    public async Task<IActionResult> Get(int Id){
        var movie = await _movieDbContext!.Movies.FirstOrDefaultAsync(x=>x.ID == Id);
        if (movie == null){
            return BadRequest("wow dude");
        }
        return Ok(movie); 
    }

   [HttpPost]

   public async Task<IActionResult> Post(Movie movie){
    await _movieDbContext!.Movies.AddAsync(movie);
    await _movieDbContext.SaveChangesAsync();

    return CreatedAtAction("Get",movie.ID,movie);
   }

   [HttpPatch]

   public async Task<IActionResult> Patch(int Id , string Country){
    var movie = await _movieDbContext!.Movies.FirstOrDefaultAsync(x=>x.ID==Id);
    if (movie==null){
        return BadRequest("bad request");
    }
    movie.Country = Country;
    await _movieDbContext.SaveChangesAsync();
    return NoContent();
   }

   [HttpDelete]

   public async Task<IActionResult> Delete(int Id){
    var movie = await _movieDbContext!.Movies.FirstOrDefaultAsync(x=>x.ID==Id);
    if (movie == null) return BadRequest("bad request");
    _movieDbContext.Movies.Remove(movie);
    await _movieDbContext.SaveChangesAsync();
    return NoContent();
   }

   
    
}