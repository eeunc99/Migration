# Migration (Skeleton)

CSV 기반 파일 마이그레이션/DB 적재용 쿼리 생성 샘플. 공개 저장소용으로 내부 경로/사내 정보를 제거한 스켈레톤입니다.

## 설정

실행 전 `Migration/App.config`의 `appSettings` 경로 값을 환경에 맞게 수정하세요.

| 키 | 설명 |
|---|---|
| LogDirectory | 로그 파일 저장 경로 |
| SourceCsvDirectory | 처리할 CSV 파일 경로 |
| SourceFileDirectory | 원본 파일 경로 |
| TargetFileDirectory | 복사 대상 경로 |

## 참고

- `Migration.vb`의 INSERT 쿼리 문자열은 로그 기록용 샘플입니다. 실제 DB에 실행할 경우 파라미터 바인딩(SqlParameter 등)으로 교체해야 합니다.
