# LAB03 - Lập trình Sockets trong C#

## Quy định chung

- **Quy trình làm việc trên Git:**
  - Trước khi bắt đầu viết code, bắt buộc chạy:
    ```
    git pull origin master
    ```
  - Sau khi hoàn thành và kiểm tra không còn lỗi biên dịch, đẩy code lên repo:

- **Quy ước đặt tên và cấu trúc Form:**
  - Không chỉnh sửa file `Dashboard.cs` và `Program.cs`.
  - Mỗi bài sử dụng file `BaiX.cs` (ví dụ `Bai1.cs`) làm Form điều hướng để mở 2 Form chức năng:
    - `BaiX_Server.cs`: Giao diện và xử lý phía Server.
    - `BaiX_Client.cs`: Giao diện và xử lý phía Client.
  - Thành viên phụ trách bài nào chỉ thao tác trong phạm vi các file của bài đó.

- **Yêu cầu bài nộp:**
  - Chương trình phải hoạt động được trên cả localhost (`127.0.0.1`) và qua mạng nội bộ (LAN).
