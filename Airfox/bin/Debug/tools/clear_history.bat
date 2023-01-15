TASKKILL /F /IM "Airfox.exe"
rmdir /S /Q "%localappdata%\Geckofx"
echo MSGBOX "The History of Airfox has been cleared successfully." > %temp%\airfoxclean_up_history.vbs
call %temp%\airfoxclean_up_history.vbs
