using Autofac;
using Beckend.DomainLayer.Repositories.CouchRepository;
using Beckend.DomainLayer.Repositories.RoomRepository;
using Beckend.DomainLayer.Repositories.TagRepository;
using Beckend.DomainLayer.Repositories.TrainingRepository;
using Beckend.DomainLayer.Services;
using Beckend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beckend.DomainLayer.autofac
{
    public class ServiceModules : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<TrainingRepository>().As<ITrainingRepository>();
            builder.RegisterType<TagRepository>().As<ITagRepository>();
            builder.RegisterType<RoomRepository>().As<IRoomRepository>();
            builder.RegisterType<CouchRepository>().As<ICouchRepository>();
            builder.RegisterType<Service>().As<IService>();

            

        }
    }
}
