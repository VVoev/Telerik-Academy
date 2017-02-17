﻿using PackageManager.Commands.Contracts;
using PackageManager.Core.Contracts;
using PackageManager.Enums;
using PackageManager.Models.Contracts;
using System;

namespace PackageManager.Commands
{
    internal class InstallCommand : ICommand
    {
        protected IInstaller<IPackage> installer;
        protected IPackage package;

        public InstallCommand(IInstaller<IPackage> installer, IPackage package)
        {
            if(installer == null)
            {
                throw new ArgumentNullException();
            }

            if (package == null)
            {
                throw new ArgumentNullException();
            }

            this.installer = installer;
            this.package = package;
            this.installer.Operation = InstallerOperation.Install;
        }

        public void Execute()
        {
            this.installer.PerformOperation(this.package);
        }
    }
}
