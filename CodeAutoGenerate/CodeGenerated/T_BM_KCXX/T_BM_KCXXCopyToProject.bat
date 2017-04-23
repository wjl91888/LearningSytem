@ECHO ON
cd %cd%\T_BM_KCXX
@ECHO 开始部署T_BM_KCXX
@ECHO 开始复制T_BM_KCXX页面文件
copy T_BM_KCXXContants.cs ..\..\..\wwwroot\App_Code\
copy T_BM_KCXXWebUIAdd.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCXXWebUIAdd.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCXXWebUIDetail.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCXXWebUIDetail.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCXXWebUIImage.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCXXWebUIImage.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCXXWebUISearch.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCXXWebUISearch.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCXXWebUIStatistic.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCXXWebUIStatistic.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCXXWebUIAddForApp.aspx ..\..\..\wwwroot\App\A_BM\T_BM_KCXXWebUIAdd.aspx
copy T_BM_KCXXWebUIAddForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\T_BM_KCXXWebUIAdd.aspx.cs
copy T_BM_KCXXWebUIDetailForApp.aspx ..\..\..\wwwroot\App\A_BM\T_BM_KCXXWebUIDetail.aspx
copy T_BM_KCXXWebUIDetailForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\T_BM_KCXXWebUIDetail.aspx.cs
copy T_BM_KCXXWebUIImage.aspx ..\..\..\wwwroot\App\A_BM\
copy T_BM_KCXXWebUIImage.aspx.cs ..\..\..\wwwroot\App\A_BM\
copy T_BM_KCXXWebUISearchForApp.aspx ..\..\..\wwwroot\App\A_BM\T_BM_KCXXWebUISearch.aspx
copy T_BM_KCXXWebUISearchForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\T_BM_KCXXWebUISearch.aspx.cs
    @ECHO 开始复制T_BM_KCXX类文件
IF NOT EXIST ..\..\..\DataLibrary\T_BM_KCXX MD ..\..\..\DataLibrary\T_BM_KCXX
copy T_BM_KCXXApplicationData.cs ..\..\..\DataLibrary\T_BM_KCXX\
IF NOT EXIST ..\..\..\DataLibrary\T_BM_KCXX\T_BM_KCXXApplicationLogic.cs copy T_BM_KCXXApplicationLogic.cs ..\..\..\DataLibrary\T_BM_KCXX\
copy T_BM_KCXXApplicationLogicBase.cs ..\..\..\DataLibrary\T_BM_KCXX\
IF NOT EXIST ..\..\..\DataLibrary\T_BM_KCXX\T_BM_KCXXBusinessEntity.cs copy T_BM_KCXXBusinessEntity.cs ..\..\..\DataLibrary\T_BM_KCXX\
copy T_BM_KCXXBusinessEntityBase.cs ..\..\..\DataLibrary\T_BM_KCXX\
IF NOT EXIST ..\..\..\DataLibrary\T_BM_KCXX\T_BM_KCXXWebUI.cs copy T_BM_KCXXWebUI.cs ..\..\..\DataLibrary\T_BM_KCXX\
copy T_BM_KCXXWebUIBase.cs ..\..\..\DataLibrary\T_BM_KCXX\
@ECHO 开始复制T_BM_KCXX数据库脚本文件
copy T_BM_KCXXScript.table.sql ..\..\..\Database\Scripts\Tables\
copy T_BM_KCXXScriptProc.sql ..\..\..\Database\Scripts\Post-Deployment\Proc\
copy T_BM_KCXXScriptPurview.sql ..\..\..\Database\Scripts\Post-Deployment\Purview\
copy T_BM_KCXXScriptUpdateField.sql ..\..\..\Database\Scripts\Post-Deployment\UpdateField\
@ECHO 开始安装T_BM_KCXX数据库脚本
echo Begin > log.log
for /f "delims=" %%a in ('dir T_BM_KCXXScriptProc.sql /s /b') do (sqlcmd -d DB_LearningSystem -i %%a >> log.log)
echo End >> log.log
@ECHO 完成安装T_BM_KCXX数据库脚本
@ECHO 完成部署T_BM_KCXX
exit

