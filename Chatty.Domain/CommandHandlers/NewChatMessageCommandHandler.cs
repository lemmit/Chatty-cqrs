using Chatty.Contracts.Commands;
using Chatty.CQRSToolkit.Logging;
using Chatty.CQRSToolkit.Validators;

namespace Chatty.Domain
{
    public class NewChatMessageCommandHandler : AbstractCommandHandler<INewChatMessageCommand>
    {
        public NewChatMessageCommandHandler(
            ICommandValidator<INewChatMessageCommand> commandValidator,
            IEventEmitter<INewChatMessageCommand> eventEmitter,
            IErrorEventEmitter<INewChatMessageCommand> errorEventEmitter,
            ILogger logger
            )
            : base(commandValidator, eventEmitter, errorEventEmitter, logger)
        {
        }

        public override void HandleCommand(INewChatMessageCommand command)
        {
        }
    }
}