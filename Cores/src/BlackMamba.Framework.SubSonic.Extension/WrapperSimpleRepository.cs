using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SubSonic.Repository;
using SubSonic.DataProviders;

namespace BlackMamba.Framework.SubSonic
{
    public class WrapperSimpleRepository : SimpleRepository,IWrapperRepository
    {
        public WrapperSimpleRepository() : this(ProviderFactory.GetProvider(),SimpleRepositoryOptions.Default) {}

        public WrapperSimpleRepository(string connectionStringName)
            : this(connectionStringName,SimpleRepositoryOptions.Default) { }

        public WrapperSimpleRepository(string connectionStringName, SimpleRepositoryOptions options)
            : this(ProviderFactory.GetProvider(connectionStringName), options) { }


        public WrapperSimpleRepository(SimpleRepositoryOptions options) : this(ProviderFactory.GetProvider(), options) { }

        public WrapperSimpleRepository(IDataProvider provider) : this(provider, SimpleRepositoryOptions.Default) {}

        public WrapperSimpleRepository(IDataProvider provider, SimpleRepositoryOptions options):base(provider,options)
        {

        }
    }
}
