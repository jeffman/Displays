# Display configuration save/restore

Windows 10 at the time of writing does not support display configuration profiles.
Use this tool to quickly save and restore different display configurations.

# Dependencies

Requires .NET Framework 4.8.

# Usage

`displays.exe record -d file.json` to record the current display configuration to `file.json`.

`displays.exe restore -d file.json` to restore a previously recorded display configuration.

# Notes

Do not edit recorded JSON files.
I originally wanted to use blobs instead of JSON (would've been simpler!) but I figure having more readable information might be useful to some.

Do not try to restore a configuration file to a different computer from which it was recorded.

I haven't tested what happens if you restore a configuration after changing your hardware.

Window states (position, size, etc.) are not saved or restored with this tool.
Consequently, if you change to a profile with fewer monitors and then change back to one with more monitors, many or all of your windows will be affinitized to one monitor instead of where they were before.
A future release may support saving and restoring of window states.
