using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LaborVolumeCalculator.Models.Dictionary;
using LaborVolumeCalculator.Models.Registers;
using LaborVolumeCalculator.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace LaborVolumeCalculator.Repositories
{
    public class NirRepository : RepositoryBase<Nir>, IRepository<Nir>
    {
        public NirRepository(DbContext context) : base(context)
        {
        }

        public override IQueryable<Nir> WithIncludes => base.WithIncludes;

    }
}