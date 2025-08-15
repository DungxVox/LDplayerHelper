LDplayerHelper

LDplayerHelper là một helper class mạnh mẽ được viết bằng C#, hỗ trợ thao tác toàn diện với LDPlayer Emulator thông qua ADB.
Thư viện này giúp lập trình viên dễ dàng quản lý nhiều phiên bản LDPlayer cùng lúc, tự động hóa thao tác, và tích hợp vào ứng dụng của mình.

✨ Tính năng chính

Khởi chạy LDPlayer theo index

Thay đổi độ phân giải và DPI

Dump UI text hoặc content qua ADB

Tìm kiếm và tương tác bằng nhận diện hình ảnh

Cài đặt hoặc mở ứng dụng theo package name

Hỗ trợ điều khiển đa luồng

Tự động kết nối lại ADB qua IP:Port

// 1) Khai báo & chuẩn bị
LDplayerHelper.pathLD = Path.Combine(txtpathLD.Text, "ldconsole.exe");
LDplayerHelper.RunCMD(LDplayerHelper.pathLD);

// 2) Xác thực số luồng với số LD hiện có
int totalLD = 1; 
bool checkDump = false;
int multiThread = Convert.ToInt32(nThread.Value) + 1;

string[] ldcount = File.ReadAllLines("ldcount.txt");
if (multiThread > ldcount.Length)
{
    MessageBox.Show("Vui lòng thiết lập số luồng tương ứng với LDPlayer hiện có");
    return;
}

// 3) Tạo danh sách "index n"
var ldIndexes = Enumerable
    .Range(1, totalLD)
    .Select(x => $"index {x}")
    .ToList();

// 4) Mở & cấu hình từng LD
foreach (var ld in ldIndexes)
{
    // Khởi động & set cấu hình
    LDplayerHelper.ChangeInfoLD(ld, 540, 960, 240, false);
    LDplayerHelper.OpenLDP(ld);
}

// (tuỳ chọn) Sắp xếp cửa sổ
LDplayerHelper.SortWnd();

// 5) Dump UI và chờ thấy chuỗi mục tiêu
checkDump = LDplayerHelper.DumpText("index 1", "Now Accepts IP/Domain", 5);
if (!checkDump) return;

// 6) Tương tác bằng ảnh (nếu có)
if (LDplayerHelper.FindImage("index 1", Resources.portproxy, 5))
    return;

// 7) Mở app theo package
LDplayerHelper.OpenPackage("index 1", "com.example.app");

// 8) Kết nối lại ADB qua serial - lấy được chuẩn serial sẽ có thể giúp bạn reconnect lại adb sau khi bị mất kết nối (thường sẽ diễn ra nếu bạn change ip trong ldplayer hoặc pc)
int thisLDIndex = 1; // ví dụ
int adbPort = LDplayerHelper.GetAdbPortFromIndex(thisLDIndex);
if (adbPort == 0) adbPort = 5555 + thisLDIndex * 2;
string serial = $"127.0.0.1:{adbPort}";
ADBServer.ConnectByIP_PORT(serial);

//Đoạn code hỗ trợ gần như đủ để bạn làm tất cả thao tác trên ldplayer - hãy xem chi tiết trong class để thấy nhiều hơn nhé!

☕ Hỗ trợ phát triển

Nếu bạn thấy LDplayerHelper hữu ích, hãy ủng hộ để mình có thêm động lực chia sẻ nhiều tính năng hay hơn:

Paypal: dvshopxyz@gmail.com

Vietinbank: 107872393669

Momo: 0934182398
