using System;
using System.Collections.Generic;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;

namespace StartWithHat
{
    /// <summary>
    /// This is the entry class for this mod.
    /// </summary>
    public class ModEntry : Mod
    {
        public IModHelper modHelper;
        public ModOptions options;
        public List<Item> startingItems;

        /// <summary>
        /// This is the entry method for this mod.
        /// </summary>
        /// <param name="helper"></param>
        public override void Entry(IModHelper helper)
        {
            this.modHelper = helper;
            SaveEvents.AfterLoad += this.SaveEvents_AfterLoad;
            this.options = this.modHelper.ReadConfig<ModOptions>();
        }

        private void SaveEvents_AfterLoad(object sender, EventArgs e)
        {
            this.ValidateOptions();
            if (Game1.player.hat.Value == null)
            {
                this.Monitor.Log($"Player {Game1.player.Name} has no hat, changing...", LogLevel.Debug);
                Game1.player.changeHat(this.options.Hat);
            }
            else
            {
                this.Monitor.Log($"Player {Game1.player.Name} has a hat, skipping...", LogLevel.Debug);
            }
        }
        
        private void ValidateOptions()
        {
            bool updateConfigFile = false;

            if (this.options.Hat < 0 || this.options.Hat > 39)
            {
                updateConfigFile = true;
                this.options.Hat = ModOptions.DefaultHat;
            }

            if (updateConfigFile)
            {
                // The configuration file has invalid option data. Re-write it so we don't do this next time.
                this.modHelper.WriteConfig(this.options);
            }
        }
    }
}