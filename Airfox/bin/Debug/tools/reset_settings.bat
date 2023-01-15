TASKKILL /F /IM "Airfox.exe"
rmdir /S /Q "%localappdata%\Geckofx"

echo MSGBOX "The Settings of Airfox have been reset." > %temp%\airfox_settings_reset.vbs
call %temp%\airfox_settings_reset.vbs
