﻿using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Services
{
    public class MovieService
    {
        private readonly MvcMovieContext _context;

        public MovieService(MvcMovieContext context)
        {
            _context = context;
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _context.Movie.SingleOrDefaultAsync(m => m.ID == id);
        }

        public async Task CreateMovieAsync(string title)
        {
            var movieEntity = new Movie()
            {
                Title = title
            };

            _context.Movie.Add(movieEntity);
            await _context.SaveChangesAsync();
        }
    }
}