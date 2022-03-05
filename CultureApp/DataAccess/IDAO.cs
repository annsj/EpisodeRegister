using CultureApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CultureApp.DataAccess
{
    public interface IDAO
    {
        Task<List<TvShow>> GetTvShows();
        Task<int> PostTvShow(TvShow show);
        Task<List<string>> GetTvShowTitles();
        Task<TvShow> GetTvShow(TvShow show);
        Task<TvShow> GetTvShowWithTitle(String title);
        string ReplaceBlank(String s);
    }
}
