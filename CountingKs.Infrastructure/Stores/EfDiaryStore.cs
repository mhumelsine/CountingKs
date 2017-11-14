using CountingKs.Core.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using CountingKs.Core.DTOs;
using CountingKs.Infrastructure.Data;
using System.Linq;

namespace CountingKs.Infrastructure.Stores
{
    public class EfDiaryStore : IDiaryStore
    {
        private readonly CountingKsContext context;
        public EfDiaryStore(CountingKsContext context)
        {
             this.context = context;
    }
        public void Add(DiaryEntry item)
        {
            context.DiaryEntries.Add(item);
        }

        public void Add(Diary item)
        {
            context.Diaries.Add(item);
        }

        public void Delete(DiaryEntry item)
        {
            context.DiaryEntries.Remove(item);
        }

        public void Delete(Diary item)
        {
            context.Diaries.Remove(item);
        }

        public IEnumerable<Diary> GetDiaries(string username)
        {
            // TODO:  Need to implement paging somehow
            return context.Diaries
                .Where(x => x.Username == username)
                .ToList();
        }

        public Diary GetDiary(int id)
        {
            return context.Diaries.Find(id);
        }

        public IEnumerable<DiaryEntry> GetDiaryEntries(string username, DateTime diaryDay)
        {
            return context.Diaries
                .Where(x => x.Username == username)
                .Where(x => x.CurrentDate == diaryDay)
                .SelectMany(x => x.Entries.Select(y => y))
                .ToList();
        }

        public DiaryEntry GetDiaryEntry(string username, DateTime diaryDay, int id)
        {
            return context.Diaries
                .Where(x => x.Username == username)
                .Where(x => x.CurrentDate == diaryDay)
                .SelectMany(x => x.Entries.Select(y => y))
                .FirstOrDefault(x => x.Id == id);
        }

        public void Update(DiaryEntry item)
        {
            context.DiaryEntries.Update(item);
        }

        public void Update(Diary item)
        {
            context.Diaries.Update(item);
        }
    }
}
