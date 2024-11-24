﻿
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;

namespace DataAccess.Concrete.EF;

public class WineRepository: EfEntityRepositoryBase<Wine, ProjectDbContext>, IWineRepository
{
    public WineRepository(ProjectDbContext context) : base(context)
    {
    }
}