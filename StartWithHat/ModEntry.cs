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
            this.Monitor.Log("Loading Start With Hat", LogLevel.Info);
            this.modHelper = helper;
            SaveEvents.BeforeCreate += this.SaveEvents_BeforeCreate;
            this.options = this.modHelper.ReadConfig<ModOptions>();
        }

        private void SaveEvents_BeforeCreate(object sender, EventArgs e)
        {
            this.ValidateOptions();

            Game1.player.changeHat(this.options.Hat);
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