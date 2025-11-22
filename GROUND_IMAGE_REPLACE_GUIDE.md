# Ground 이미지 교체 가이드

## 📐 이미지 규격
- **크기**: 2176 × 1472 픽셀
- **Pixels Per Unit**: 64
- **Pivot**: Center (0.5, 0.5)

## 🔧 단계별 교체 방법

### 1단계: 새 이미지를 Unity 프로젝트에 추가

1. **Unity 에디터 열기**
   - `Assets/Scenes/level.unity` 씬을 엽니다

2. **이미지 파일 복사**
   - 만든 2176×1472 이미지 파일을 준비합니다
   - 파일 탐색기(Finder)에서 `Assets/Sprites/` 폴더로 이미지 파일을 복사합니다
     - 또는 Unity 에디터에서 `Assets > Sprites` 폴더를 우클릭 → `Import New Asset...` 선택

3. **이미지 임포트 확인**
   - Project 창에서 새로 추가된 이미지 파일이 보이는지 확인합니다

---

### 2단계: 이미지 Import Settings 설정

1. **이미지 선택**
   - Project 창에서 방금 추가한 이미지를 클릭합니다

2. **Inspector 창에서 설정 변경**
   - Inspector 창의 하단에 Import Settings가 표시됩니다
   - 다음 설정을 변경합니다:

   **📝 Texture Type**
   - `Sprite (2D and UI)` 선택
   
   **📝 Texture Shape**
   - `2D` 유지 (기본값)
   
   **📝 Pixels Per Unit**
   - `64` 입력 (현재 타일과 동일하게 설정)
   
   **📝 Filter Mode**
   - `Point (no filter)` 또는 `Bilinear` (원하는 대로)
   
   **📝 Compression**
   - 원하는 압축 설정 (일반적으로 `None` 또는 `Low`)

3. **Apply 버튼 클릭**
   - Inspector 하단의 `Apply` 버튼을 클릭하여 설정을 적용합니다

---

### 3단계: 타일맵 비활성화 또는 숨기기 (선택)

**옵션 A: 타일맵 비활성화 (추천)**
- Hierarchy 창에서 `Grid` GameObject를 찾습니다
- `Grid` 왼쪽의 체크박스를 해제하여 비활성화합니다
- 이렇게 하면 나중에 필요하면 다시 활성화할 수 있습니다

**옵션 B: 타일맵 삭제**
- Hierarchy 창에서 `Grid` GameObject를 선택합니다
- Delete 키를 누르거나 우클릭 → `Delete` 선택
- 확인 대화상자에서 `Delete` 클릭

---

### 4단계: 새 Sprite GameObject 생성

1. **GameObject 생성**
   - Hierarchy 창에서 빈 공간을 우클릭합니다
   - `2D Object > Sprites > Sprite` 선택
   - 또는 `GameObject > Create Empty` 선택 후 SpriteRenderer 컴포넌트 추가

2. **이름 변경**
   - 새로 생성된 GameObject를 선택합니다
   - Hierarchy 창 상단에서 이름을 `Ground` 또는 `GroundSprite`로 변경합니다

---

### 5단계: SpriteRenderer 설정

1. **SpriteRenderer 컴포넌트 확인**
   - 새 GameObject를 선택한 상태에서 Inspector 창을 확인합니다
   - SpriteRenderer 컴포넌트가 없으면:
     - Inspector 하단에서 `Add Component` 클릭
     - `Sprite Renderer` 검색 후 선택

2. **Sprite 할당**
   - Inspector 창의 SpriteRenderer 섹션에서
   - `Sprite` 필드 옆의 작은 원형 아이콘을 클릭합니다
   - 또는 `Sprite` 필드에 Project 창의 새 이미지를 드래그 앤 드롭합니다
   - Sprite 선택 창에서 방금 임포트한 이미지를 선택합니다

---

### 6단계: Transform 위치 및 크기 설정

1. **Transform 컴포넌트 확인**
   - Inspector 창에서 Transform 컴포넌트를 확인합니다

2. **Position 설정**
   - 현재 타일맵의 Origin이 (-17, -13)이고 Size가 (34, 23)입니다
   - 타일맵의 중심은: X: -17 + 34/2 = 0, Y: -13 + 23/2 = -1.5
   
   **설정 값:**
   - **Position X**: `0`
   - **Position Y**: `-1.5`
   - **Position Z**: `0`

3. **Scale 확인**
   - **Scale X**: `1` (기본값 유지)
   - **Scale Y**: `1` (기본값 유지)
   - **Scale Z**: `1` (기본값 유지)
   
   ⚠️ **참고**: 이미지가 정확한 크기(2176×1472 픽셀)이고 Pixels Per Unit이 64로 설정되어 있다면,
   Scale을 (34, 23, 1)로 설정할 필요가 없습니다. Unity가 자동으로 계산합니다.

4. **Rotation 확인**
   - 모든 축: `0` (기본값 유지)

---

### 7단계: Sorting Layer 및 Order 설정

1. **Sorting Layer 설정**
   - SpriteRenderer 컴포넌트에서 `Sorting Layer` 확인
   - 현재 타일맵과 같은 Sorting Layer를 사용하거나 적절한 레이어 선택
   - 타일맵의 Sorting Layer를 확인하려면:
     - Hierarchy에서 `Grid > Tilemap` 선택
     - Inspector에서 TilemapRenderer의 Sorting Layer 확인

2. **Order in Layer 설정**
   - `Order in Layer` 값을 타일맵과 동일하게 설정
   - 타일맵의 Order in Layer가 `-27`이었으므로 동일하게 `-27` 설정
   - 또는 원하는 값으로 조정 (낮을수록 뒤에 렌더링됨)

---

### 8단계: 최종 확인 및 조정

1. **Scene 뷰 확인**
   - Scene 뷰에서 새 Ground 이미지가 올바른 위치에 표시되는지 확인합니다
   - 타일맵이 있던 위치와 겹치는지 확인합니다

2. **Game 뷰 확인**
   - Play 모드로 전환하여 실제 게임에서 어떻게 보이는지 확인합니다
   - 필요하면 Position을 미세 조정합니다

3. **크기 조정이 필요한 경우**
   - 이미지가 작거나 크게 보이면:
     - Transform의 Scale을 조정합니다
     - 또는 Import Settings의 Pixels Per Unit을 조정합니다

---

## ✅ 체크리스트

- [ ] 새 이미지 파일을 `Assets/Sprites/` 폴더에 추가했나요?
- [ ] Import Settings에서 Texture Type을 `Sprite (2D and UI)`로 설정했나요?
- [ ] Pixels Per Unit을 `64`로 설정했나요?
- [ ] Apply 버튼을 눌러 설정을 적용했나요?
- [ ] 기존 타일맵(Grid)을 비활성화하거나 삭제했나요?
- [ ] 새 Sprite GameObject를 생성했나요?
- [ ] SpriteRenderer에 새 이미지를 할당했나요?
- [ ] Transform Position을 (0, -1.5, 0)으로 설정했나요?
- [ ] Sorting Layer와 Order in Layer를 적절히 설정했나요?
- [ ] Scene/Game 뷰에서 올바르게 표시되는지 확인했나요?

---

## 🔍 문제 해결

### 이미지가 너무 크거나 작게 보이는 경우
- Import Settings의 `Pixels Per Unit` 값을 조정하거나
- Transform의 `Scale` 값을 조정하세요

### 이미지가 잘못된 위치에 있는 경우
- Transform의 `Position` 값을 조정하세요
- 타일맵의 정확한 범위를 확인하려면 타일맵을 다시 활성화하고 비교하세요

### 이미지가 다른 오브젝트와 겹치는 경우
- SpriteRenderer의 `Sorting Layer` 또는 `Order in Layer`를 조정하세요

---

## 📝 참고 사항

- **이미지 크기**: 정확히 2176 × 1472 픽셀
- **Pixels Per Unit**: 64 (타일 하나 = 64×64 픽셀 = 1×1 Unity unit)
- **타일맵 크기**: 34 × 23 타일
- **타일맵 Origin**: (-17, -13)
- **이미지 중심 위치**: (0, -1.5)

위치 계산 공식:
- X 중심 = Origin X + (Size X / 2) = -17 + (34 / 2) = 0
- Y 중심 = Origin Y + (Size Y / 2) = -13 + (23 / 2) = -1.5
