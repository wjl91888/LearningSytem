@ECHO ON
cd %cd%\T_BM_BMXX
@ECHO 开始部署T_BM_BMXX
@ECHO 开始复制T_BM_BMXX页面文件
copy T_BM_BMXXContants.cs ..\..\..\wwwroot\App_Code\
copy T_BM_BMXXWebUIAdd.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_BMXXWebUIAdd.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_BMXXWebUIDetail.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_BMXXWebUIDetail.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_BMXXWebUIImage.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_BMXXWebUIImage.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_BMXXWebUISearch.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_BMXXWebUISearch.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_BMXXWebUIStatistic.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_BMXXWebUIStatistic.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_BMXXWebUIAddForApp.aspx ..\..\..\wwwroot\App\A_BM\T_BM_BMXXWebUIAdd.aspx
copy T_BM_BMXXWebUIAddForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\T_BM_BMXXWebUIAdd.aspx.cs
copy T_BM_BMXXWebUIDetailForApp.aspx ..\..\..\wwwroot\App\A_BM\T_BM_BMXXWebUIDetail.aspx
copy T_BM_BMXXWebUIDetailForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\T_BM_BMXXWebUIDetail.aspx.cs
copy T_BM_BMXXWebUIImage.aspx ..\..\..\wwwroot\App\A_BM\
copy T_BM_BMXXWebUIImage.aspx.cs ..\..\..\wwwroot\App\A_BM\
copy T_BM_BMXXWebUISearchForApp.aspx ..\..\..\wwwroot\App\A_BM\T_BM_BMXXWebUISearch.aspx
copy T_BM_BMXXWebUISearchForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\T_BM_BMXXWebUISearch.aspx.cs
    @ECHO 开始复制T_BM_BMXX类文件
IF NOT EXIST ..\..\..\DataLibrary\T_BM_BMXX MD ..\..\..\DataLibrary\T_BM_BMXX
copy T_BM_BMXXApplicationData.cs ..\..\..\DataLibrary\T_BM_BMXX\
IF NOT EXIST ..\..\..\DataLibrary\T_BM_BMXX\T_BM_BMXXApplicationLogic.cs copy T_BM_BMXXApplicationLogic.cs ..\..\..\DataLibrary\T_BM_BMXX\
copy T_BM_BMXXApplicationLogicBase.cs ..\..\..\DataLibrary\T_BM_BMXX\
IF NOT EXIST ..\..\..\DataLibrary\T_BM_BMXX\T_BM_BMXXBusinessEntity.cs copy T_BM_BMXXBusinessEntity.cs ..\..\..\DataLibrary\T_BM_BMXX\
copy T_BM_BMXXBusinessEntityBase.cs ..\..\..\DataLibrary\T_BM_BMXX\
IF NOT EXIST ..\..\..\DataLibrary\T_BM_BMXX\T_BM_BMXXWebUI.cs copy T_BM_BMXXWebUI.cs ..\..\..\DataLibrary\T_BM_BMXX\
copy T_BM_BMXXWebUIBase.cs ..\..\..\DataLibrary\T_BM_BMXX\
@ECHO 开始复制T_BM_BMXX数据库脚本文件
copy T_BM_BMXXScript.table.sql ..\..\..\Database\Scripts\Tables\
copy T_BM_BMXXScriptProc.sql ..\..\..\Database\Scripts\Post-Deployment\Proc\
copy T_BM_BMXXScriptPurview.sql ..\..\..\Database\Scripts\Post-Deployment\Purview\
copy T_BM_BMXXScriptUpdateField.sql ..\..\..\Database\Scripts\Post-Deployment\UpdateField\
@ECHO 开始安装T_BM_BMXX数据库脚本
echo Begin > log.log
for /f "delims=" %%a in ('dir T_BM_BMXXScriptProc.sql /s /b') do (sqlcmd -d DB_LearningSystem -i %%a >> log.log)
echo End >> log.log
@ECHO 完成安装T_BM_BMXX数据库脚本
@ECHO 完成部署T_BM_BMXX
exit

