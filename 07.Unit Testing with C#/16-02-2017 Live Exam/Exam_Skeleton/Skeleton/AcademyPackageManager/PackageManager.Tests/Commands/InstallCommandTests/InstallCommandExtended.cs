using PackageManager.Commands;
using PackageManager.Core.Contracts;
using PackageManager.Models.Contracts;

namespace PackageManager.Tests.Commands.InstallCommandTests
{
     class InstallCommandExtended : InstallCommand
    {
        public InstallCommandExtended(IInstaller<IPackage> installer, IPackage package) : base(installer, package)
        {
        }

        public IInstaller<IPackage> Installer
        {
            get
            {
                return this.installer;
            }
            set
            {
                this.installer = value;
            }
        }

        public IPackage Package
        {
            get
            {
                return this.package;
            }
            set
            {
                this.package = value;
            }
        }
    }
}
