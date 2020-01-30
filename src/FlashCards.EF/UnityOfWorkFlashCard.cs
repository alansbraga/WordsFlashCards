using ASB.EF;
using FlashCards.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashCards.EF
{
    public class UnityOfWorkFlashCard : UnidadeTrabalho, IUnityOfWorkFlashCard
    {
        public DbSet<FlashCard> FlashCard { get; set; }
        public DbSet<Collection> Collection { get; set; }
        public DbSet<FlashCardCollection> FlashCardCollection { get; set; }
        public DbSet<Sample> Sample { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=d:/tmp/Flashcards.db");
        }
    }
}
