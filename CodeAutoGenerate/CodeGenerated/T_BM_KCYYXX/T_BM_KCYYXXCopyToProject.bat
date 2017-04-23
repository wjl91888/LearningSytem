@ECHO ON
cd %cd%\T_BM_KCYYXX
@ECHO 开始部署T_BM_KCYYXX
@ECHO 开始复制T_BM_KCYYXX页面文件
copy T_BM_KCYYXXContants.cs ..\..\..\wwwroot\App_Code\
copy T_BM_KCYYXXWebUIAdd.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCYYXXWebUIAdd.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCYYXXWebUIDetail.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCYYXXWebUIDetail.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCYYXXWebUIImage.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCYYXXWebUIImage.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCYYXXWebUISearch.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCYYXXWebUISearch.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCYYXXWebUIStatistic.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCYYXXWebUIStatistic.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCYYXXWebUIAddForApp.aspx ..\..\..\wwwroot\App\A_BM\T_BM_KCYYXXWebUIAdd.aspx
copy T_BM_KCYYXXWebUIAddForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\T_BM_KCYYXXWebUIAdd.aspx.cs
copy T_BM_KCYYXXWebUIDetailForApp.aspx ..\..\..\wwwroot\App\A_BM\T_BM_KCYYXXWebUIDetail.aspx
copy T_BM_KCYYXXWebUIDetailForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\T_BM_KCYYXXWebUIDetail.aspx.cs
copy T_BM_KCYYXXWebUIImage.aspx ..\..\..\wwwroot\App\A_BM\
copy T_BM_KCYYXXWebUIImage.aspx.cs ..\..\..\wwwroot\App\A_BM\
copy T_BM_KCYYXXWebUISearchForApp.aspx ..\..\..\wwwroot\App\A_BM\T_BM_KCYYXXWebUISearch.aspx
copy T_BM_KCYYXXWebUISearchForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\T_BM_KCYYXXWebUISearch.aspx.cs
    @ECHO 开始复制T_BM_KCYYXX类文件
IF NOT EXIST ..\..\..\DataLibrary\T_BM_KCYYXX MD ..\..\..\DataLibrary\T_BM_KCYYXX
copy T_BM_KCYYXXApplicationData.cs ..\..\..\DataLibrary\T_BM_KCYYXX\
IF NOT EXIST ..\..\..\DataLibrary\T_BM_KCYYXX\T_BM_KCYYXXApplicationLogic.cs copy T_BM_KCYYXXApplicationLogic.cs ..\..\..\DataLibrary\T_BM_KCYYXX\
copy T_BM_KCYYXXApplicationLogicBase.cs ..\..\..\DataLibrary\T_BM_KCYYXX\
IF NOT EXIST ..\..\..\DataLibrary\T_BM_KCYYXX\T_BM_KCYYXXBusinessEntity.cs copy T_BM_KCYYXXBusinessEntity.cs ..\..\..\DataLibrary\T_BM_KCYYXX\
copy T_BM_KCYYXXBusinessEntityBase.cs ..\..\..\DataLibrary\T_BM_KCYYXX\
IF NOT EXIST ..\..\..\DataLibrary\T_BM_KCYYXX\T_BM_KCYYXXWebUI.cs copy T_BM_KCYYXXWebUI.cs ..\..\..\DataLibrary\T_BM_KCYYXX\
copy T_BM_KCYYXXWebUIBase.cs ..\..\..\DataLibrary\T_BM_KCYYXX\
@ECHO 开始复制T_BM_KCYYXX数据库脚本文件
copy T_BM_KCYYXXScript.table.sql ..\..\..\Database\Scripts\Tables\
copy T_BM_KCYYXXScriptProc.sql ..\..\..\Database\Scripts\Post-Deployment\Proc\
copy T_BM_KCYYXXScriptPurview.sql ..\..\..\Database\Scripts\Post-Deployment\Purview\
copy T_BM_KCYYXXScriptUpdateField.sql ..\..\..\Database\Scripts\Post-Deployment\UpdateField\
@ECHO 开始安装T_BM_KCYYXX数据库脚本
echo Begin > log.log
for /f "delims=" %%a in ('dir T_BM_KCYYXXScriptProc.sql /s /b') do (sqlcmd -d DB_LearningSystem -i %%a >> log.log)
echo End >> log.log
@ECHO 完成安装T_BM_KCYYXX数据库脚本
@ECHO 完成部署T_BM_KCYYXX
exit

