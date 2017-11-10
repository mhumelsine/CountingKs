using CountingKs.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CountingKs.Core.Stores
{
    public interface IDiaryStore : IAddable<DiaryEntry>, IAddable<Diary>, IUpdatable<DiaryEntry>, IUpdatable<Diary>, IDeletable<DiaryEntry>, IDeletable<Diary>
    {
        IEnumerable<Diary> GetDiaries(string username);
        Diary GetDiary(int id);
        IEnumerable<DiaryEntry> GetDiaryEntries(string username, DateTime diaryDay);

        DiaryEntry GetDiaryEntry(string username, DateTime diaryDay, int id);
    }
}
