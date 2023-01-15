
TASKKILL /F /IM "Airfox.exe"
rmdir /S /Q "%localappdata%\Geckofx"

echo MSGBOX "The browsing data of Airfox has been cleared successfully." > %temp%\airfox_clear_browsing_data.vbs
call %temp%\airfox_clear_browsing_data.vbs
