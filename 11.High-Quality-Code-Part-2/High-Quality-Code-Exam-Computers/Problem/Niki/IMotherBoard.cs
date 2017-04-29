namespace Computers.UI.Common
{
    public interface IMotherboard
    {
        /// <summary>
        /// Load value from the ram
        /// </summary>
        /// <returns>The Loaded Value</returns>
        int LoadRamValue();

        /// <summary>
        /// Save value from the ram
        /// </summary>
        /// <param name="value">the value to save</param>
        void SaveRamValue(int value);

        /// <summary>
        /// Draws text in the videocard
        /// </summary>
        /// <param name="data">The data you required videocard to draw</param>
        void DrawOnVideoCard(string data);
    }
}
