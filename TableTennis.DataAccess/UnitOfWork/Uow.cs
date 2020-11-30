using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TableTennis.DataAccess.DBContext;
using TableTennis.DataAccess.Entities;
using TableTennis.DataAccess.Generics;

namespace TableTennis.DataAccess.UnitOfWork
{
    public class Uow : IUoW
    {
        private ApplicationDbContext DbContext { get; set; }

        public Uow(ApplicationDbContext _DbContext)
        {
            DbContext = _DbContext;
        }
        public void Commit()
        {
            DbContext.SaveChanges();
        }

        public IRepository<Schedule> ScheduleRepository
        {
            get { return new Repository<Schedule>(DbContext); }
        }

        public IRepository<Team> TeamRepository
        {
            get { return new Repository<Team>(DbContext); }
        }

        public IRepository<TeamMatch> TeamMatchRepository
        {
            get { return new Repository<TeamMatch>(DbContext); }
        }

        public IRepository<TeamMember> TeamMemberRepository
        {
            get { return new Repository<TeamMember>(DbContext); }
        }

        public IRepository<ApplicationUser> ApplicationUserRepository
        {
            get { return new Repository<ApplicationUser>(DbContext); }
        }
    }

    public interface IUoW
    {
        void Commit();

        IRepository<Schedule> ScheduleRepository { get; }
        IRepository<Team> TeamRepository { get; }
        IRepository<TeamMatch> TeamMatchRepository { get; }
        IRepository<TeamMember> TeamMemberRepository { get; }

        IRepository<ApplicationUser> ApplicationUserRepository { get; }

    }

}
