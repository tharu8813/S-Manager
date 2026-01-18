namespace S_Manager.Start {
    public partial class TermsOfUse : Form {
        public TermsOfUse() {
            InitializeComponent();
        }

        private void TermsOfUse_Load(object sender, EventArgs e) {
            InitializeWebView2();
        }

        private async void InitializeWebView2() {
            // User Data Folder를 명시적으로 설정하여 임시 폴더 문제 해결
            string userDataFolder = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                "S_Manager",
                "WebView2"
            );

            var env = await Microsoft.Web.WebView2.Core.CoreWebView2Environment.CreateAsync(null, userDataFolder);
            await webView21.EnsureCoreWebView2Async(env);

            // 강조, 색상은 유지하되 메시지 창은 표시하지 않는 HTML 콘텐츠
            string htmlContent = @"
                <!DOCTYPE html>
                <html lang='ko'>
                <head>
                    <meta charset='UTF-8'>
                    <title>서비스 이용 약관</title>
                    <style>
                        body { 
                            font-family: Arial, sans-serif; 
                            margin: 0; 
                            padding: 0; 
                            background-color: #f3f4f6; 
                        }
                        .container { 
                            max-width: 800px; 
                            margin: 50px auto; 
                            padding: 20px; 
                        }
                        h1 { 
                            font-size: 2.5rem; 
                            margin-bottom: 30px; 
                            text-align: center; 
                            color: #333; 
                        }
                        .card { 
                            background: white; 
                            padding: 20px; 
                            margin-bottom: 20px; 
                            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1); 
                            border-radius: 8px; 
                            transition: transform 0.2s, box-shadow 0.2s;
                        }
                        .card:hover { 
                            transform: translateY(-5px); 
                            box-shadow: 0 8px 16px rgba(0, 0, 0, 0.15); 
                        }
                        p { 
                            line-height: 1.8; 
                            margin: 10px 0; 
                            color: #555; 
                        }
                        footer { 
                            margin-top: 40px; 
                            font-size: 0.9rem; 
                            color: #777; 
                            text-align: center; 
                        }
                        /* 강조 스타일 */
                        .highlight { 
                            color: #d9534f; /* 강조 색상 (빨강) */
                            font-weight: bold; 
                            transition: color 0.3s;
                        }
                        .highlight:hover { 
                            color: #c9302c; /* 호버 시 색상 변경 */
                            text-decoration: underline; 
                        }
                    </style>
                </head>
                <body>
                    <div class='container'>
                        <h1>서비스 이용 약관</h1>

                        <div class='card'>
                            <p>
                                본 프로그램은 <span class='highlight'>Red Dead Redemption 2 게임의 온라인 시스템</span>에서 
                                사용자에게 안전한 세션을 제공하기 위해 제작되었습니다.
                                그러나 본 프로그램의 사용으로 인해 발생할 수 있는 <span class='highlight'>모든 피해와 손해</span>에 대해 
                                제작자는 어떠한 책임도 지지 않습니다.
                            </p>
                        </div>

                        <div class='card'>
                            <p>
                                사용자는 본 프로그램을 사용함에 있어 게임의 이용 약관 및 정책을 충분히 숙지하고, 이를 준수해야 합니다.
                                <span class='highlight'>모든 결과는 전적으로 사용자의 책임</span>입니다.
                            </p>
                        </div>

                        <div class='card'>
                            <p>
                                본 프로그램의 사용으로 인해 <span class='highlight'>게임 계정 정지</span>, 
                                데이터 손실, 법적 문제 등 예상치 못한 결과가 발생할 수 있으니 주의하시기 바랍니다.
                            </p>
                        </div>

                        <footer>
                            &copy; 2025 S_Manager 프로그램. 모든 권리 보유.
                        </footer>
                    </div>
                </body>
                </html>";

            webView21.CoreWebView2.NavigateToString(htmlContent);
        }
    }
}
