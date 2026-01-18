using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace S_Manager.Tools {
    internal class Tool {

        /// <summary>
        /// 어플리케이션의 경로를 가져옵니다.
        /// </summary>
        public static string AppPath = Application.StartupPath;

        /// <summary>
        /// 메세지 박스의 타입을 나타냅니다.
        /// </summary>
        public enum MessageType {
            Info,
            Warning,
            Error,
            Question
        }

        /// <summary>
        /// 어플리케이션의 제품 이름을 가져옵니다.
        /// </summary>
        /// <returns>어플리케이션 이름</returns>
        public static string? GetProductName() {
            return Application.ProductName;
        }

        /// <summary>
        /// 메세지 박스를 표시합니다.
        /// </summary>
        /// <param name="text">메세지</param>
        /// <param name="massageType">메세지 타입</param>
        /// <returns>메세지에서 사용자가 선택한 항목</returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static DialogResult ShowMessage(string text, MessageType messageType) {
            return messageType switch {
                MessageType.Info => MessageBox.Show(text, $"{Application.ProductName} - 정보", MessageBoxButtons.OK, MessageBoxIcon.Information),
                MessageType.Warning => MessageBox.Show(text, $"{Application.ProductName} - 경고", MessageBoxButtons.OK, MessageBoxIcon.Warning),
                MessageType.Error => MessageBox.Show(text, $"{Application.ProductName} - 오류", MessageBoxButtons.OK, MessageBoxIcon.Error),
                MessageType.Question => MessageBox.Show(text, $"{Application.ProductName} - 질문", MessageBoxButtons.YesNo, MessageBoxIcon.Question),
                _ => throw new ArgumentOutOfRangeException(nameof(messageType), messageType, null)
            };
        }

        /// <summary>
        /// 코드를 세션으로 변환합니다.
        /// </summary>
        /// <param name="code">변경할 코드입니다.</param>
        /// <returns>xml</returns>
        /// <exception cref="Exception"></exception>
        public static string CodeSession(string code) {
            char[] specialChars = { '<', '>', '!', '-', '?' };
            if (code.Any(c => specialChars.Contains(c))) {
                throw new Exception("특수문자는 포함될 수 없습니다. '<', '>', '!', '-', '?'");
            }
            return $"""
                <?xml version="1.0" encoding="UTF-8" ?>
                <CDataFileMgr__ContentsOfDataFileXml>
                	<disabledFiles />
                	<includedXmlFiles itemType="CDataFileMgr__DataFileArray" />
                	<includedDataFiles />
                	<dataFiles itemType="CDataFileMgr__DataFile">
                		<Item>
                			<filename>platform:/data/cdimages/scaleform_platform_pc.rpf</filename>
                			<fileType>RPF_FILE</fileType>
                		</Item>
                		<Item>
                			<filename>platform:/data/ui/value_conversion.rpf</filename>
                			<fileType>RPF_FILE</fileType>
                		</Item>
                		<Item>
                			<filename>platform:/data/ui/widgets.rpf</filename>
                			<fileType>RPF_FILE</fileType>
                		</Item>
                		<Item>
                			<filename>platform:/textures/ui/ui_photo_stickers.rpf</filename>
                			<fileType>RPF_FILE</fileType>
                		</Item>
                		<Item>
                			<filename>platform:/textures/ui/ui_platform.rpf</filename>
                			<fileType>RPF_FILE</fileType>
                		</Item>
                		<Item>
                			<filename>platform:/data/ui/stylesCatalog</filename>
                			<fileType>aWeaponizeDisputants</fileType>
                			<!-- collision -->
                		</Item>
                		<Item>
                			<filename>platform:/data/cdimages/scaleform_frontend.rpf</filename>
                			<fileType>RPF_FILE_PRE_INSTALL</fileType>
                		</Item>
                		<Item>
                			<filename>platform:/textures/ui/ui_startup_textures.rpf</filename>
                			<fileType>RPF_FILE</fileType>
                		</Item>
                		<Item>
                			<filename>platform:/data/ui/startup_data.rpf</filename>
                			<fileType>RPF_FILE</fileType>
                		</Item>
                	</dataFiles>
                	<contentChangeSets itemType="CDataFileMgr__ContentChangeSet" />
                	<patchFiles />
                </CDataFileMgr__ContentsOfDataFileXml> S_Manager가 생성한 비밀번호입니다. 지우지 마세요! 삭제를 원한다면 S_Manager 프로그램에서 공개 세션으로 변경해주세요. {code}
                """;
        }

        /// <summary>
        /// 특정 파일에서 시작 마커 이후의 모든 내용을 추출합니다.
        /// </summary>
        /// <param name="filePath">읽을 파일의 경로</param>
        /// <param name="startMarker">내용 추출을 시작할 마커 문자열</param>
        /// <returns>마커 이후의 모든 내용 (없으면 빈 문자열 반환)</returns>
        public static string ExtractContentFromFile(string filePath, string startMarker) {
            if (!File.Exists(filePath)) {
                Console.WriteLine("파일을 찾을 수 없습니다.");
                return string.Empty;
            }

            string fileContent = File.ReadAllText(filePath);
            int startIndex = fileContent.IndexOf(startMarker);

            if (startIndex != -1) {
                startIndex += startMarker.Length;
                return fileContent[startIndex..].Trim(); // 앞뒤 공백 제거 후 반환
            }

            Console.WriteLine($"'{startMarker}' 텍스트를 찾을 수 없습니다.");
            return string.Empty;
        }

        /// <summary>
        /// 랜덤 비밀번호를 생성합니다.
        /// </summary>
        /// <param name="length">비밀번호 글자 수</param>
        /// <returns>랜덤 비밀번호</returns>
        public static string GenerateRandomPassword(int length) {
            const string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            StringBuilder password = new StringBuilder(length);

            using (RandomNumberGenerator rng = RandomNumberGenerator.Create()) {
                byte[] randomBytes = new byte[4];

                for (int i = 0; i < length; i++) {
                    rng.GetBytes(randomBytes);
                    int randomIndex = Math.Abs(BitConverter.ToInt32(randomBytes, 0)) % validChars.Length;
                    password.Append(validChars[randomIndex]);
                }
            }

            return password.ToString();
        }

        /// <summary>
        /// 탐색기를 특정 경로로 엽니다.
        /// </summary>
        /// <param name="path"></param>
        public static void OpenExplorerAtPath(string path) {
            if (Directory.Exists(path)) {
                System.Diagnostics.Process.Start("explorer.exe", path);
            } else {
                MessageBox.Show("해당 경로를 찾을 수 없습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Red Dead Redemption 2를 종료합니다.
        /// </summary>
        /// <param name="text"></param>
        public static void RDR2Exit(string text) {
            if (IsRDR2Running()) {
                if (Tool.ShowMessage($"{text}\n\n현재 Red Dead Redemption 2가 실행중입니다. Red Dead Redemption 2를 실행했을 경우 다시시작을 해야합니다.\nRed Dead Redemption 2를 강제 종료하시겠습니까? 강제종료시 진행중인 사항을 저장되지 않습니다. 수동 종료를 추천합니다.", Tool.MessageType.Question) == DialogResult.Yes) {
                    int i = 0;
                    foreach (var process in Process.GetProcessesByName("RDR2")) {
                        process.Kill();
                        process.WaitForExit();
                        i++;
                    }
                    if (i == 0) Tool.ShowMessage("Red Dead Redemption 2가 실행되어있지 않습니다.", MessageType.Error);
                }
            } else {
                Tool.ShowMessage($"{text}", MessageType.Info);
            }

        }

        /// <summary>
        /// Red Dead Redemption 2가 실행 중인지 확인합니다.
        /// </summary>
        /// <returns></returns>
        public static bool IsRDR2Running() {
            // "RDR2"는 Red Dead Redemption 2의 실행 파일 이름 (확장자 .exe 제외)
            return Process.GetProcessesByName("RDR2").Length > 0;
        }
    }
}
