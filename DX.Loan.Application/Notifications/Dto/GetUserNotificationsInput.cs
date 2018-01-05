using Abp.Notifications;
using DX.Loan.Dto;

namespace DX.Loan.Notifications.Dto
{
    public class GetUserNotificationsInput : PagedInputDto
    {
        public UserNotificationState? State { get; set; }
    }
}