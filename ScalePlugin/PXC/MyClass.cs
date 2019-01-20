/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2019/1/20 星期日
 * 时间: 12:39
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Windows.Forms;
using PXCPlugin;
using PEPlugin.Pmx;
using PEPlugin.SDX;
using SlimDX;
using System.Threading;
// -------------------------<< ここから固定 >>-------------------------
namespace PXCPlugin
{
    public class Register : RegisterBase
    {
        public override string[] ClassNames
        {
            get
            {
                // 対象プラグインを namespace からフルネームで記述(複数指定可能)
                // 文字列は「namespace名称.CPluginClass」と記述する。
                return new string[]{
                    "PXC.CPluginClass"      //与namespaceの名称相同
                };
            }
        }
    }
}
// -------------------------<< ここまで固定 >>-------------------------


// プラグイン処理
//namespaceの名称は特に制限されない。
//「PXCPluginSample」という名称は適時書き換える事
namespace PXC
{
    public class CPluginClass : PXCPluginClass
    {
        /// <summary>
        /// PMDEditerを操作するために必要な変数群
        /// </summary>
        //-----------------------------------------------------------ここから-----------------------------------------------------------
        public IPXCPluginRunArgs args;
        public IPXCPluginConnector conn;
        public IPXCPrimitiveBuilder pb;
        public IPXPmx PMX;
        public PXCPlugin.UIModel.IPXUIModel scale;
        //-----------------------------------------------------------ここまで-----------------------------------------------------------
        //「プラグイン名」と「プラグインのメニュー表記名」を空にした場合はメニュー未登録状態になる。（推奨はされない。）
        public override string Name
        {
            get { return "插件名"; }
        }

        public override string Version
        {
            get { return "版本号"; }
        }

        public override string Description
        {
            get { return "插件说明"; }
        }

        public override string MenuText
        {
            get { return "测量身高插件"; }
        }

        public override void Run(IPXCPluginRunArgs args)
        {
            base.Run(args);
            try
            {
                //PMXファイルを操作するためにおまじない。
                this.args = args;
                this.conn = args.Connector;
                this.PMX = PXCBridge.GetCurrentPmx(this.conn);

                //-----------------------------------------------------------ここから-----------------------------------------------------------
                //ここから処理開始
                //-----------------------------------------------------------ここから-----------------------------------------------------------

				System.Diagnostics.Process.Start("http://walogia.ucoz.club/donate.html");  
				
				
				IPXPmx iPXPmx = base.m_bld.Pmx();
				iPXPmx.FromFile(System.IO.Directory.GetCurrentDirectory()+@"\_plugin\User\Scale\model\Scale by iRon0129.pmx");
				this.scale=PXCBridge.RegisterUIModel(args.Connector, iPXPmx, "不知道起什么", null, true, true);
                //-----------------------------------------------------------ここまで-----------------------------------------------------------
                //処理ここまで
                //-----------------------------------------------------------ここまで-----------------------------------------------------------
                //必要がある場合はモデル・画面を更新します。
                Thread.Sleep(10000);
                scale.Release();
                	
                this.Update();

            }
            catch (Exception ex)
            {
                // 例外処理
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// モデル・画面を更新します。
        /// </summary>
        public void Update()
        {
            PXCBridge.UpdatePmx(this.conn, this.PMX);
        }
        

        
    }
    
}