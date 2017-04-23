@ECHO ON
cd %cd%\T_BM_KCXLXX
@ECHO 开始部署T_BM_KCXLXX
@ECHO 开始复制T_BM_KCXLXX页面文件
copy T_BM_KCXLXXContants.cs ..\..\..\wwwroot\App_Code\
copy T_BM_KCXLXXWebUIAdd.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCXLXXWebUIAdd.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCXLXXWebUIDetail.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCXLXXWebUIDetail.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCXLXXWebUIImage.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCXLXXWebUIImage.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCXLXXWebUISearch.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCXLXXWebUISearch.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCXLXXWebUIStatistic.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCXLXXWebUIStatistic.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCXLXXWebUIAddForApp.aspx ..\..\..\wwwroot\App\A_BM\T_BM_KCXLXXWebUIAdd.aspx
copy T_BM_KCXLXXWebUIAddForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\T_BM_KCXLXXWebUIAdd.aspx.cs
copy T_BM_KCXLXXWebUIDetailForApp.aspx ..\..\..\wwwroot\App\A_BM\T_BM_KCXLXXWebUIDetail.aspx
copy T_BM_KCXLXXWebUIDetailForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\T_BM_KCXLXXWebUIDetail.aspx.cs
copy T_BM_KCXLXXWebUIImage.aspx ..\..\..\wwwroot\App\A_BM\
copy T_BM_KCXLXXWebUIImage.aspx.cs ..\..\..\wwwroot\App\A_BM\
copy T_BM_KCXLXXWebUISearchForApp.aspx ..\..\..\wwwroot\App\A_BM\T_BM_KCXLXXWebUISearch.aspx
copy T_BM_KCXLXXWebUISearchForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\T_BM_KCXLXXWebUISearch.aspx.cs
    @ECHO 开始复制T_BM_KCXLXX类文件
IF NOT EXIST ..\..\..\DataLibrary\T_BM_KCXLXX MD ..\..\..\DataLibrary\T_BM_KCXLXX
copy T_BM_KCXLXXApplicationData.cs ..\..\..\DataLibrary\T_BM_KCXLXX\
IF NOT EXIST ..\..\..\DataLibrary\T_BM_KCXLXX\T_BM_KCXLXXApplicationLogic.cs copy T_BM_KCXLXXApplicationLogic.cs ..\..\..\DataLibrary\T_BM_KCXLXX\
copy T_BM_KCXLXXApplicationLogicBase.cs ..\..\..\DataLibrary\T_BM_KCXLXX\
IF NOT EXIST ..\..\..\DataLibrary\T_BM_KCXLXX\T_BM_KCXLXXBusinessEntity.cs copy T_BM_KCXLXXBusinessEntity.cs ..\..\..\DataLibrary\T_BM_KCXLXX\
copy T_BM_KCXLXXBusinessEntityBase.cs ..\..\..\DataLibrary\T_BM_KCXLXX\
IF NOT EXIST ..\..\..\DataLibrary\T_BM_KCXLXX\T_BM_KCXLXXWebUI.cs copy T_BM_KCXLXXWebUI.cs ..\..\..\DataLibrary\T_BM_KCXLXX\
copy T_BM_KCXLXXWebUIBase.cs ..\..\..\DataLibrary\T_BM_KCXLXX\
@ECHO 开始复制T_BM_KCXLXX数据库脚本文件
copy T_BM_KCXLXXScript.table.sql ..\..\..\Database\Scripts\Tables\
copy T_BM_KCXLXXScriptProc.sql ..\..\..\Database\Scripts\Post-Deployment\Proc\
copy T_BM_KCXLXXScriptPurview.sql ..\..\..\Database\Scripts\Post-Deployment\Purview\
copy T_BM_KCXLXXScriptUpdateField.sql ..\..\..\Database\Scripts\Post-Deployment\UpdateField\
@ECHO 开始安装T_BM_KCXLXX数据库脚本
echo Begin > log.log
for /f "delims=" %%a in ('dir T_BM_KCXLXXScriptProc.sql /s /b') do (sqlcmd -d DB_LearningSystem -i %%a >> log.log)
echo End >> log.log
@ECHO 完成安装T_BM_KCXLXX数据库脚本
@ECHO 完成部署T_BM_KCXLXX
exit

