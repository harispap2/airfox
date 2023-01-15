TASKKILL /F /IM "Airfox.exe"
rmdir /S /Q "%localappdata%\Geckofx"

echo MSGBOX "The Advanced Settings of Airfox have been reset." > %temp%\airfox_advanced_settings_reset.vbs
call %temp%\airfox_advanced_settings_reset.vbs