using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.DTOs;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private readonly ApplicationDbContext _dbcontext;

        public MoviesController()
        {
            _dbcontext = new ApplicationDbContext();
        }

        public IEnumerable<MovieDTO> GetMovies()
        {
            var data = _dbcontext.Movies.Include(c => c.Genre).ToList().Select(Mapper.Map<Movie, MovieDTO>);
            return data;
        }

        // GET/api/movie/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _dbcontext.Movies.SingleOrDefault(c => c.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Movie, MovieDTO>(movie));
        }
        //POST /api/movie/

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDTO, Movie>(movieDto);
            _dbcontext.Movies.Add(movie);
            _dbcontext.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }


        // PUT /api/Movies/1
        [HttpPut]
        public void UpdateMovie(int id, MovieDTO movieDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var movieInDb = _dbcontext.Movies.SingleOrDefault(c => c.Id == id);

            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(movieDto, movieInDb);

            _dbcontext.SaveChanges();
        }


        //DELTE /api/Movies/1
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var MovieInDb = _dbcontext.Movies.SingleOrDefault(c => c.Id == id);

            if (MovieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _dbcontext.Movies.Remove(MovieInDb);
            _dbcontext.SaveChanges();
        }
    }
}
