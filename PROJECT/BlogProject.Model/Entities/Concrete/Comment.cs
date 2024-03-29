﻿using BlogProject.Model.Entities.Abstract;

namespace BlogProject.Model.Entities.Concrete
{
    public class Comment :BaseEntity
    {
        public string Text { get; set; }

        // navigation prop

        // 1 yorum 1 kulanıcıya aittir.

        public int AppUserId { get; set; }
        public AppUser  AppUser { get; set; }

        // 1 yorum 1 makaleye aittir.

        public int ArticleId { get; set; }

        public Article  Article { get; set; }
    }
}