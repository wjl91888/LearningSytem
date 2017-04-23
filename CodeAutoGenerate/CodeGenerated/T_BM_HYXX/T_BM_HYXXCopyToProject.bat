@ECHO ON
cd %cd%\T_BM_HYXX
@ECHO 开始部署T_BM_HYXX
@ECHO 开始复制T_BM_HYXX页面文件
copy T_BM_HYXXContants.cs ..\..\..\wwwroot\App_Code\
copy T_BM_HYXXWebUIAdd.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_HYXXWebUIAdd.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_HYXXWebUIDetail.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_HYXXWebUIDetail.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_HYXXWebUIImage.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_HYXXWebUIImage.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_HYXXWebUISearch.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_HYXXWebUISearch.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_HYXXWebUIStatistic.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_HYXXWebUIStatistic.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_HYXXWebUIAddForApp.aspx ..\..\..\wwwroot\App\A_BM\T_BM_HYXXWebUIAdd.aspx
copy T_BM_HYXXWebUIAddForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\T_BM_HYXXWebUIAdd.aspx.cs
copy T_BM_HYXXWebUIDetailForApp.aspx ..\..\..\wwwroot\App\A_BM\T_BM_HYXXWebUIDetail.aspx
copy T_BM_HYXXWebUIDetailForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\T_BM_HYXXWebUIDetail.aspx.cs
copy T_BM_HYXXWebUIImage.aspx ..\..\..\wwwroot\App\A_BM\
copy T_BM_HYXXWebUIImage.aspx.cs ..\..\..\wwwroot\App\A_BM\
copy T_BM_HYXXWebUISearchForApp.aspx ..\..\..\wwwroot\App\A_BM\T_BM_HYXXWebUISearch.aspx
copy T_BM_HYXXWebUISearchForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\T_BM_HYXXWebUISearch.aspx.cs
    @ECHO 开始复制T_BM_HYXX类文件
IF NOT EXIST ..\..\..\DataLibrary\T_BM_HYXX MD ..\..\..\DataLibrary\T_BM_HYXX
copy T_BM_HYXXApplicationData.cs ..\..\..\DataLibrary\T_BM_HYXX\
IF NOT EXIST ..\..\..\DataLibrary\T_BM_HYXX\T_BM_HYXXApplicationLogic.cs copy T_BM_HYXXApplicationLogic.cs ..\..\..\DataLibrary\T_BM_HYXX\
copy T_BM_HYXXApplicationLogicBase.cs ..\..\..\DataLibrary\T_BM_HYXX\
IF NOT EXIST ..\..\..\DataLibrary\T_BM_HYXX\T_BM_HYXXBusinessEntity.cs copy T_BM_HYXXBusinessEntity.cs ..\..\..\DataLibrary\T_BM_HYXX\
copy T_BM_HYXXBusinessEntityBase.cs ..\..\..\DataLibrary\T_BM_HYXX\
IF NOT EXIST ..\..\..\DataLibrary\T_BM_HYXX\T_BM_HYXXWebUI.cs copy T_BM_HYXXWebUI.cs ..\..\..\DataLibrary\T_BM_HYXX\
copy T_BM_HYXXWebUIBase.cs ..\..\..\DataLibrary\T_BM_HYXX\
@ECHO 开始复制T_BM_HYXX数据库脚本文件
copy T_BM_HYXXScript.table.sql ..\..\..\Database\Scripts\Tables\
copy T_BM_HYXXScriptProc.sql ..\..\..\Database\Scripts\Post-Deployment\Proc\
copy T_BM_HYXXScriptPurview.sql ..\..\..\Database\Scripts\Post-Deployment\Purview\
copy T_BM_HYXXScriptUpdateField.sql ..\..\..\Database\Scripts\Post-Deployment\UpdateField\
@ECHO 开始安装T_BM_HYXX数据库脚本
echo Begin > log.log
for /f "delims=" %%a in ('dir T_BM_HYXXScriptProc.sql /s /b') do (sqlcmd -d DB_LearningSystem -i %%a >> log.log)
echo End >> log.log
@ECHO 完成安装T_BM_HYXX数据库脚本
@ECHO 完成部署T_BM_HYXX
exit

