using System;

namespace Dealership.Engine
{
    public interface ICommandHandler
    {
        void SetSuccessor(ICommandHandler commandHandler);

        string Handle(ICommand command);
    }

    public abstract class CommandHandler : ICommandHandler
    {
        private ICommandHandler Successor { get; set; }

        protected abstract bool CanHandle(ICommand command);

        protected abstract string HandlerInternal(ICommand command);
   
        public string Handle(ICommand command)
        {
            if (this.CanHandle(command))
            {
                return this.HandlerInternal(command);
            }
            
            if(this.Successor != null)
            {
                return this.Successor.Handle(command);
            }

            return string.Format(DealershipEngine.InvalidCommand, command.Name);
        }

        public void SetSuccessor(ICommandHandler commandHandler)
        {
            this.Successor = commandHandler;
        }
    }
}