@ECHO ON
cd %cd%\T_BM_KCBXX
@ECHO ��ʼ����T_BM_KCBXX
@ECHO ��ʼ����T_BM_KCBXXҳ���ļ�
copy T_BM_KCBXXContants.cs ..\..\..\wwwroot\App_Code\
copy T_BM_KCBXXWebUIAdd.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCBXXWebUIAdd.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCBXXWebUIDetail.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCBXXWebUIDetail.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCBXXWebUIImage.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCBXXWebUIImage.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCBXXWebUISearch.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCBXXWebUISearch.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCBXXWebUIStatistic.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCBXXWebUIStatistic.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_KCBXXWebUIAddForApp.aspx ..\..\..\wwwroot\App\A_BM\T_BM_KCBXXWebUIAdd.aspx
copy T_BM_KCBXXWebUIAddForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\T_BM_KCBXXWebUIAdd.aspx.cs
copy T_BM_KCBXXWebUIDetailForApp.aspx ..\..\..\wwwroot\App\A_BM\T_BM_KCBXXWebUIDetail.aspx
copy T_BM_KCBXXWebUIDetailForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\T_BM_KCBXXWebUIDetail.aspx.cs
copy T_BM_KCBXXWebUIImage.aspx ..\..\..\wwwroot\App\A_BM\
copy T_BM_KCBXXWebUIImage.aspx.cs ..\..\..\wwwroot\App\A_BM\
copy T_BM_KCBXXWebUISearchForApp.aspx ..\..\..\wwwroot\App\A_BM\T_BM_KCBXXWebUISearch.aspx
copy T_BM_KCBXXWebUISearchForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\T_BM_KCBXXWebUISearch.aspx.cs
    @ECHO ��ʼ����T_BM_KCBXX���ļ�
IF NOT EXIST ..\..\..\DataLibrary\T_BM_KCBXX MD ..\..\..\DataLibrary\T_BM_KCBXX
copy T_BM_KCBXXApplicationData.cs ..\..\..\DataLibrary\T_BM_KCBXX\
IF NOT EXIST ..\..\..\DataLibrary\T_BM_KCBXX\T_BM_KCBXXApplicationLogic.cs copy T_BM_KCBXXApplicationLogic.cs ..\..\..\DataLibrary\T_BM_KCBXX\
copy T_BM_KCBXXApplicationLogicBase.cs ..\..\..\DataLibrary\T_BM_KCBXX\
IF NOT EXIST ..\..\..\DataLibrary\T_BM_KCBXX\T_BM_KCBXXBusinessEntity.cs copy T_BM_KCBXXBusinessEntity.cs ..\..\..\DataLibrary\T_BM_KCBXX\
copy T_BM_KCBXXBusinessEntityBase.cs ..\..\..\DataLibrary\T_BM_KCBXX\
IF NOT EXIST ..\..\..\DataLibrary\T_BM_KCBXX\T_BM_KCBXXWebUI.cs copy T_BM_KCBXXWebUI.cs ..\..\..\DataLibrary\T_BM_KCBXX\
copy T_BM_KCBXXWebUIBase.cs ..\..\..\DataLibrary\T_BM_KCBXX\
@ECHO ��ʼ����T_BM_KCBXX���ݿ�ű��ļ�
copy T_BM_KCBXXScript.table.sql ..\..\..\Database\Scripts\Tables\
copy T_BM_KCBXXScriptProc.sql ..\..\..\Database\Scripts\Post-Deployment\Proc\
copy T_BM_KCBXXScriptPurview.sql ..\..\..\Database\Scripts\Post-Deployment\Purview\
copy T_BM_KCBXXScriptUpdateField.sql ..\..\..\Database\Scripts\Post-Deployment\UpdateField\
@ECHO ��ʼ��װT_BM_KCBXX���ݿ�ű�
echo Begin > log.log
for /f "delims=" %%a in ('dir T_BM_KCBXXScriptProc.sql /s /b') do (sqlcmd -d DB_LearningSystem -i %%a >> log.log)
echo End >> log.log
@ECHO ��ɰ�װT_BM_KCBXX���ݿ�ű�
@ECHO ��ɲ���T_BM_KCBXX
exit

