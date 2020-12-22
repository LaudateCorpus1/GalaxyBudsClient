﻿using GalaxyBudsClient.Platform.Interfaces;
using Serilog;
using ThePBone.MprisClient;
using Tmds.DBus;

namespace GalaxyBudsClient.Platform.Linux
{
    public class MediaKeyRemote : IMediaKeyRemote
    {
        private readonly MprisClient _client = new MprisClient();
        
        public void Play()
        {
            try
            {
                _client.Player?.PlayAsync();
                Log.Debug("Linux.MediaKeyRemote: Play request sent");
            }
            catch (DBusException ex)
            {
                Log.Error($"{ex.ErrorName}: {ex.ErrorMessage}");
            }
        }

        public void Pause()
        {
            try
            {
                _client.Player?.PauseAsync();
                Log.Debug("Linux.MediaKeyRemote: Pause request sent");
            }
            catch (DBusException ex)
            {
                Log.Error($"{ex.ErrorName}: {ex.ErrorMessage}");
            }
        }
    }
}