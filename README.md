# LAB03 - Lập trình Sockets trong C#

## Quy định chung

- **Quy trình làm việc trên Git:**
  - Làm việc trực tiếp trên nhánh `master`.
  - Trước khi bắt đầu viết code, bắt buộc chạy:
    ```
    git pull origin master
    ```
  - Sau khi hoàn thành và kiểm tra không còn lỗi biên dịch, đẩy code lên repo:
   
- **Quy ước thư mục và cấu trúc Form:**
  - Không chỉnh sửa file `Dashboard.cs` và `Program.cs`.
  - Mỗi thành viên tự tạo một thư mục riêng cho bài của mình tại thư mục gốc của project (ví dụ: `Bai01`, `Bai02`, ...).
  - Toàn bộ file của bài nào phải nằm gọn trong thư mục bài đó:
    - `BaiX.cs`: Form điều hướng trung gian (chứa 2 nút bấm để mở Client và Server).
    - `BaiX_Server.cs`: Giao diện và mã nguồn xử lý phía Server.
    - `BaiX_Client.cs`: Giao diện và mã nguồn xử lý phía Client.
  - **Lưu ý quan trọng về Namespace:** Tất cả các file `.cs` tạo mới trong thư mục bài đều phải đặt `namespace LAB03` để liên kết thông với `Dashboard.cs`.

- **Yêu cầu kỹ thuật bài nộp:**
  - Chương trình phải hoạt động được trên cả localhost (`127.0.0.1`) và qua LAN.
