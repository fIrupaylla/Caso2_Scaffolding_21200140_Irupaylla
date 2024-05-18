using Caso2_Scaffolding_21200140_Irupaylla.DOMAIN.Core.Interfaces;
using Caso2_Scaffolding_21200140_Irupaylla.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caso2_Scaffolding_21200140_Irupaylla.DOMAIN.Infrastructure.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly Parcial20240121200140Context _dbContext;

        public MovieRepository(Parcial20240121200140Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Movies>> GetAll()
        {
            var movies = await _dbContext
                                .Movies
                                .ToListAsync();

            return movies;
        }

        public async Task<Movies> GetById(int id)
        {
            return await _dbContext
                    .Movies
                    .Where(m => m.Id == id)
                    .FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Movies movies)
        {
            await _dbContext.AddAsync(movies);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Update(Movies movies)
        {
            _dbContext.Movies.Update(movies);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var findMovie = await _dbContext
                .Movies
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            if (findMovie == null) return false;

            _dbContext.Movies.Remove(findMovie);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
        public async Task<bool> DeleteLogic(int id)
        {
            var findMovie = await _dbContext
                   .Movies
                   .Where(x => x.Id == id)
                   .FirstOrDefaultAsync();

            if (findMovie == null) return false;


            int rows = await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
