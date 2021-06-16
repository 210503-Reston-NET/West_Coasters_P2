using System;
using System.ComponentModel.DataAnnotations;
using Models;
using Xunit;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using DL;
using System.Threading.Tasks;

namespace Tests
{
    public class EquipmentRepoTest
    {
        private readonly DbContextOptions<AppDBContext> options;
        public EquipmentRepoTest() {
            options = new DbContextOptionsBuilder<AppDBContext>().UseSqlite("Filename=Test.db").Options;
        }
        
    }
}