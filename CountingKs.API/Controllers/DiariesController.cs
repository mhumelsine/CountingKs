using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CountingKs.Core.Stores;
using System.Threading;

namespace CountingKs.API.Controllers
{
    [Produces("application/json")]
    [Route("api/user/diaries")]
    public class DiariesController : Controller
    {
        private readonly IDiaryStore diaryStore;
        private readonly ModelFactory modelFactory;
        public DiariesController(IDiaryStore diaryStore, ModelFactory modelFactory)
        {
            this.diaryStore = diaryStore;
            this.modelFactory = modelFactory;
        }
        [Route("", Name = RouteName.DiaryList)]
        public IActionResult Get() {
            var username = "michael";
            var results = diaryStore.GetDiaries(username)
                .Select(x => modelFactory.Create(x));

            return Ok(results);
        }

       // public IActionResult Get(int diaryId) { }
    }
}