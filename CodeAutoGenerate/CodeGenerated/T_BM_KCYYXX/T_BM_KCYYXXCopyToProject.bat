@ECHO ON
cd %cd%\T_BM_KCYYXX
@ECHO ��ʼ����T_BM_KCYYXX
@ECHO ��ʼ����T_BM_KCYYXXҳ���ļ�
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
    @ECHO ��ʼ����T_BM_KCYYXX���ļ�
IF NOT EXIST ..\..\..\DataLibrary\T_BM_KCYYXX MD ..\..\..\DataLibrary\T_BM_KCYYXX
copy T_BM_KCYYXXApplicationData.cs ..\..\..\DataLibrary\T_BM_KCYYXX\
IF NOT EXIST ..\..\..\DataLibrary\T_BM_KCYYXX\T_BM_KCYYXXApplicationLogic.cs copy T_BM_KCYYXXApplicationLogic.cs ..\..\..\DataLibrary\T_BM_KCYYXX\
copy T_BM_KCYYXXApplicationLogicBase.cs ..\..\..\DataLibrary\T_BM_KCYYXX\
IF NOT EXIST ..\..\..\DataLibrary\T_BM_KCYYXX\T_BM_KCYYXXBusinessEntity.cs copy T_BM_KCYYXXBusinessEntity.cs ..\..\..\DataLibrary\T_BM_KCYYXX\
copy T_BM_KCYYXXBusinessEntityBase.cs ..\..\..\DataLibrary\T_BM_KCYYXX\
IF NOT EXIST ..\..\..\DataLibrary\T_BM_KCYYXX\T_BM_KCYYXXWebUI.cs copy T_BM_KCYYXXWebUI.cs ..\..\..\DataLibrary\T_BM_KCYYXX\
copy T_BM_KCYYXXWebUIBase.cs ..\..\..\DataLibrary\T_BM_KCYYXX\
@ECHO ��ʼ����T_BM_KCYYXX���ݿ�ű��ļ�
copy T_BM_KCYYXXScript.table.sql ..\..\..\Database\Scripts\Tables\
copy T_BM_KCYYXXScriptProc.sql ..\..\..\Database\Scripts\Post-Deployment\Proc\
copy T_BM_KCYYXXScriptPurview.sql ..\..\..\Database\Scripts\Post-Deployment\Purview\
copy T_BM_KCYYXXScriptUpdateField.sql ..\..\..\Database\Scripts\Post-Deployment\UpdateField\
@ECHO ��ʼ��װT_BM_KCYYXX���ݿ�ű�
echo Begin > log.log
for /f "delims=" %%a in ('dir T_BM_KCYYXXScriptProc.sql /s /b') do (sqlcmd -d DB_LearningSystem -i %%a >> log.log)
echo End >> log.log
@ECHO ��ɰ�װT_BM_KCYYXX���ݿ�ű�
@ECHO ��ɲ���T_BM_KCYYXX
exit

