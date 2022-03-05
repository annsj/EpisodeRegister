using CultureApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CultureApp.DataAccess
{
    public class DAO : IDAO
    {
        private readonly CultureContext _context;

        public DAO(CultureContext context)
        {
            _context = context;
        }

        public async Task<List<TvShow>> GetTvShows()
        {
            List<TvShow> tvShows = await _context.Tvshows
                .OrderBy(t => t.Title)
                .ToListAsync();

            return tvShows;
        }

        public async Task<int> PostTvShow(TvShow postedShow)
        {
            var show = await _context.Tvshows.FirstOrDefaultAsync(t => t.Title == postedShow.Title);

            if (show == null)
            {
                await _context.Tvshows.AddAsync(postedShow);
            }

            else
            {
                show.Season = postedShow.Season;
                show.Episode = postedShow.Episode;
            }

            int entries = await _context.SaveChangesAsync();

            return entries;
        }

        public async Task<List<string>> GetTvShowTitles()
        {
            return await _context.Tvshows
                .GroupBy(t => t.Title)
                .Select(g => g.Key)
                .OrderBy(s => s)
                .ToListAsync();
        }

        public async Task<TvShow> GetTvShow(TvShow postedShow)
        {
            var show = await _context.Tvshows.FirstOrDefaultAsync(t => t.Title == postedShow.Title);
            return show;
        }

        public async Task<TvShow> GetTvShowWithTitle(string title)
        {
            TvShow show = await _context.Tvshows.FirstOrDefaultAsync(t => t.Title == title);

            return show;
        }

        public string ReplaceBlank(String s)
        {
            s.Replace(" ", "&nbsp");

            return s;
        }
    }
}
