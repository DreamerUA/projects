using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Tutor.Core;
using System.Web.Mvc;
using Tutor.Interfaces;
using Tutor.Data.Repository;

namespace Tutor.Web.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IReviewRepository>().To<ReviewRepository>();
            kernel.Bind<IUserRepository>().To<UserRepository>();
            kernel.Bind<IUserInfoRepository>().To<UserInfoRepository>();
            kernel.Bind<ISkillRepository>().To<SkillRepository>();
            kernel.Bind<ISummaryRepository>().To<SummaryRepository>();
            kernel.Bind<IVacancyRepository>().To<VacancyRepository>();


            kernel.Bind<IUniversalRepository>().To<UniversalRepository>();
        }
    }
}