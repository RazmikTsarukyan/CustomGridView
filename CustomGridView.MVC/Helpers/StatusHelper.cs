using CustomGridView.Entities.Enums;

namespace CustomGridView.MVC.Helpers
{
    public static class StatusHelper
    {
        public static string GetStatus(Statuses statusId)
        {
            return statusId.ToString();
        }
    }
}
