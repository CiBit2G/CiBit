using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.DTO
{
    public class CibitDb: DbContext
    {
        public CibitDb(DbContextOptions<CibitDb> options): base(options)
        {

        }

        public virtual DbSet<TransactionDTO> Transactions { get; set; }
        public virtual DbSet<CoinDTO> Coins { get; set; }

    }
}
