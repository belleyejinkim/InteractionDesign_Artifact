# 3단계: HealthWarningUI 스크립트 설정 - 상세 가이드

## 🎯 목표
HealthWarningPanel에 HealthWarningUI 스크립트 컴포넌트를 추가하고, 필요한 필드들을 연결하는 것입니다.

---

## 📝 단계별 상세 설명

### Step 3-1: HealthWarningPanel GameObject 선택

1. **Unity 에디터 열기**
   - `Assets/Scenes/level.unity` 씬이 열려있는지 확인합니다

2. **Hierarchy 창에서 HealthWarningPanel 찾기**
   - Hierarchy 창의 맨 위에서 아래로 스크롤하면서 `Canvas`를 찾습니다
   - `Canvas`를 펼쳐서 (왼쪽 화살표 클릭) 자식 요소들을 확인합니다
   - 그 안에서 **`HealthWarningPanel`**을 찾습니다
   - 만약 아직 만들지 않았다면 1단계로 돌아가서 먼저 만드세요

3. **HealthWarningPanel 선택**
   - Hierarchy에서 **`HealthWarningPanel`**을 **클릭**하여 선택합니다
   - 선택되면 Inspector 창에 해당 GameObject의 컴포넌트들이 표시됩니다

---

### Step 3-2: HealthWarningUI 컴포넌트 추가

1. **Inspector 창 확인**
   - HealthWarningPanel을 선택한 상태에서 Inspector 창을 확인합니다
   - 현재 RectTransform과 Image 컴포넌트가 있을 것입니다

2. **Add Component 버튼 클릭**
   - Inspector 창의 **맨 아래쪽**에 있는 **`Add Component`** 버튼을 클릭합니다
   - 버튼을 클릭하면 검색 창과 컴포넌트 목록이 나타납니다

3. **HealthWarningUI 스크립트 검색**
   - 검색 창에 `Health Warning` 또는 `HealthWarningUI`를 입력합니다
   - 또는 `health`만 입력해도 관련 컴포넌트가 나타납니다
   - 목록에서 **`Health Warning UI (Script)`** 또는 **`HealthWarningUI`**를 찾습니다

4. **컴포넌트 추가**
   - **`Health Warning UI (Script)`**를 클릭합니다
   - 그러면 Inspector 창에 **Health Warning UI** 컴포넌트가 추가됩니다

---

### Step 3-3: Artifact 필드 설정

1. **Artifact 필드 찾기**
   - Inspector 창에서 방금 추가한 **Health Warning UI** 컴포넌트를 찾습니다
   - 컴포넌트 내부에 여러 필드가 표시됩니다:
     - Artifact (None)
     - Warning Image (None)
     - Warning Text (None)
     - Warning Health Threshold (30)
     - Display Duration (2)

2. **Artifact GameObject 찾기**
   - Hierarchy 창에서 **`artifact`** (소문자) GameObject를 찾습니다
   - Tip: Hierarchy 창 상단의 검색창에 `artifact`를 입력하면 빠르게 찾을 수 있습니다
   - **`artifact`** GameObject는 Tag가 "Artifact"로 설정되어 있습니다

3. **Artifact 필드에 할당**
   - **방법 1 (드래그 앤 드롭 - 추천)**:
     - Hierarchy 창에서 **`artifact`** GameObject를 찾습니다
     - **`artifact`**를 **마우스로 클릭하고 끌어서** (드래그)
     - Inspector 창의 **Health Warning UI** 컴포넌트에서 **`Artifact`** 필드로 가져갑니다 (드롭)
     - 그러면 `Artifact (None)` → `Artifact (artifact)`로 변경됩니다
   
   - **방법 2 (원형 아이콘 클릭)**:
     - Inspector의 **`Artifact`** 필드 옆에 있는 **작은 원형 아이콘** (🎯)을 클릭합니다
     - 나타나는 창에서 **`artifact`**를 검색하여 선택합니다
     - **Select** 또는 **Apply**를 클릭합니다

4. **확인**
   - Artifact 필드가 `None`이 아닌 `artifact`로 표시되어야 합니다

---

### Step 3-4: Warning Image 필드 설정

1. **Warning Image GameObject 확인**
   - Hierarchy 창에서 **`HealthWarningPanel`**을 펼쳐서 자식 요소들을 확인합니다
   - 그 안에 **`WarningImage`** GameObject가 있는지 확인합니다

2. **Warning Image 필드에 할당**
   - Hierarchy 창에서 **`WarningImage`** GameObject를 클릭하여 선택합니다
   - Inspector 창의 **Health Warning UI** 컴포넌트에서 **`Warning Image`** 필드를 찾습니다
   - **방법 1**: **`WarningImage`**를 드래그해서 **`Warning Image`** 필드로 드롭
   - **방법 2**: **`Warning Image`** 필드 옆의 원형 아이콘을 클릭하여 `WarningImage` 선택

3. **확인**
   - Warning Image 필드가 `WarningImage`로 표시되어야 합니다

---

### Step 3-5: Warning Text 필드 설정

1. **Warning Text GameObject 확인**
   - Hierarchy 창에서 **`HealthWarningPanel`**을 펼쳐서 자식 요소들을 확인합니다
   - 그 안에 **`WarningText`** GameObject가 있는지 확인합니다

2. **Warning Text 필드에 할당**
   - Hierarchy 창에서 **`WarningText`** GameObject를 클릭하여 선택합니다
   - Inspector 창의 **Health Warning UI** 컴포넌트에서 **`Warning Text`** 필드를 찾습니다
   - **방법 1**: **`WarningText`**를 드래그해서 **`Warning Text`** 필드로 드롭
   - **방법 2**: **`Warning Text`** 필드 옆의 원형 아이콘을 클릭하여 `WarningText` 선택

3. **확인**
   - Warning Text 필드가 `WarningText`로 표시되어야 합니다

---

### Step 3-6: 추가 설정 확인

1. **Warning Health Threshold 확인**
   - Inspector의 **Health Warning UI** 컴포넌트에서 **`Warning Health Threshold`** 값을 확인합니다
   - 기본값은 `30`입니다
   - 필요하면 다른 값으로 변경할 수 있습니다 (지금은 30으로 유지)

2. **Display Duration 확인**
   - Inspector의 **Health Warning UI** 컴포넌트에서 **`Display Duration`** 값을 확인합니다
   - 기본값은 `2`입니다 (2초)
   - 필요하면 다른 값으로 변경할 수 있습니다 (지금은 2로 유지)

---

## ✅ Step 3 완료 체크리스트

모든 단계를 완료했는지 확인하세요:

- [ ] HealthWarningPanel GameObject를 선택했습니다
- [ ] Health Warning UI 컴포넌트를 추가했습니다
- [ ] Artifact 필드에 `artifact` GameObject를 할당했습니다
- [ ] Warning Image 필드에 `WarningImage` GameObject를 할당했습니다
- [ ] Warning Text 필드에 `WarningText` GameObject를 할당했습니다
- [ ] Warning Health Threshold가 30으로 설정되어 있습니다
- [ ] Display Duration이 2로 설정되어 있습니다

---

## 🔍 문제 해결

### Artifact 필드를 찾을 수 없는 경우
- Hierarchy 창에서 `artifact` GameObject가 있는지 확인하세요
- 검색창에 `artifact`를 입력하여 찾아보세요
- GameObject의 이름이 정확히 `artifact` (소문자)인지 확인하세요

### Warning Image/Text 필드를 찾을 수 없는 경우
- Hierarchy에서 HealthWarningPanel을 펼쳐서 자식 요소들을 확인하세요
- WarningImage와 WarningText GameObject가 제대로 생성되었는지 확인하세요
- GameObject 이름이 정확한지 확인하세요 (대소문자 구분)

### 필드에 할당 후에도 None으로 표시되는 경우
- 다시 한 번 드래그 앤 드롭을 시도해보세요
- GameObject가 제대로 선택되었는지 확인하세요
- Unity 에디터를 저장하고 다시 시도해보세요 (Ctrl+S 또는 Cmd+S)

### 컴포넌트가 나타나지 않는 경우
- 스크립트 파일이 `Assets/Scripts/UI/HealthWarningUI.cs`에 있는지 확인하세요
- Unity 에디터에서 스크립트를 컴파일할 시간을 기다려보세요 (상단 진행 바 확인)
- Project 창에서 `HealthWarningUI.cs`를 선택하여 다시 임포트해보세요

---

## 📸 시각적 참고

### Inspector 창 모습 (완료 후):
```
Health Warning UI (Script)
├─ Artifact: artifact ✅
├─ Warning Image: WarningImage ✅
├─ Warning Text: WarningText ✅
├─ Warning Health Threshold: 30
└─ Display Duration: 2
```

### Hierarchy 창 구조 (참고):
```
Canvas
├─ ... (다른 UI 요소들)
└─ HealthWarningPanel
   ├─ WarningImage
   └─ WarningText
```

---

## 🎯 다음 단계

Step 3를 완료했다면 **Step 4 (5단계)**로 넘어가세요:
- WarningImage와 WarningText GameObject를 기본적으로 비활성화해야 합니다
- 스크립트가 자동으로 health가 30이 될 때 활성화합니다

---

**Step 3 완료! 이제 5단계(초기 상태 설정)로 넘어가세요!** 🎉
