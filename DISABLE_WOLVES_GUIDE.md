# Wolf와 WolfEater 비활성화 가이드

## ✅ 완료된 작업
- EnemySpawner 컴포넌트를 비활성화했습니다 (m_Enabled: 0)
- 이제 게임 실행 시 wolf와 wolfEater가 스폰되지 않습니다

## 📍 비활성화된 위치
- **GameObject**: `Manager` (Hierarchy 창에서 찾을 수 있음)
- **컴포넌트**: `EnemySpawner`
- **상태**: 비활성화됨 (Disabled)

---

## 🔄 Unity 에디터에서 확인 및 조작 방법

### EnemySpawner 비활성화 확인
1. Unity 에디터를 엽니다
2. `Assets/Scenes/level.unity` 씬을 엽니다
3. Hierarchy 창에서 **`Manager`** GameObject를 찾습니다
4. `Manager`를 선택합니다
5. Inspector 창에서 **`EnemySpawner`** 컴포넌트를 확인합니다
6. 컴포넌트 이름 옆의 **체크박스가 해제**되어 있어야 합니다 (비활성화 상태)

### 나중에 다시 활성화하려면
1. Hierarchy 창에서 **`Manager`** GameObject를 선택합니다
2. Inspector 창에서 **`EnemySpawner`** 컴포넌트를 찾습니다
3. 컴포넌트 이름 옆의 **체크박스를 체크**합니다
4. 그러면 다시 wolf와 wolfEater가 스폰됩니다

---

## 🔍 추가 정보

### EnemySpawner가 하는 일
- `EnemySpawner` 컴포넌트는 일정 시간마다 wolf와 wolfEater를 스폰합니다
- 현재 설정:
  - **spawnTime**: 12초 (초기 스폰 딜레이)
  - **spawnReductionPer**: 1초 (각 스폰마다 딜레이 감소)
  - **spawnFloor**: 3.5초 (최소 스폰 딜레이)
  - **eaterChance**: 3 (10마리 중 3마리 확률로 wolfEater 스폰)

### 비활성화 효과
- ✅ wolf (일반 늑대) 스폰 중단
- ✅ wolfEater (붉은 늑대, 부시를 먹는 적) 스폰 중단
- ✅ 이미 스폰된 wolf/wolfEater는 게임 시작 시 없습니다
- ⚠️ 만약 게임이 진행 중이라면, 이미 스폰된 적들은 남아있을 수 있습니다

### 이미 스폰된 적 제거
만약 게임 중에 이미 스폰된 wolf/wolfEater를 제거하려면:
1. Hierarchy 창에서 `wolf` 또는 `wolfEater` 이름을 가진 GameObject를 찾습니다
2. 해당 GameObject들을 삭제하거나 비활성화합니다
3. 또는 게임을 다시 시작하면 새로운 적이 스폰되지 않습니다

---

## 📝 변경 사항 요약

**변경된 파일**: `Assets/Scenes/level.unity`
- EnemySpawner 컴포넌트의 `m_Enabled` 값을 `1`에서 `0`으로 변경

이 변경으로 인해:
- ✅ wolf와 wolfEater의 스폰이 완전히 중단됩니다
- ✅ 게임을 더 쉽게 테스트하거나 플레이할 수 있습니다
- ✅ 필요시 Unity 에디터에서 간단히 다시 활성화할 수 있습니다

---

## ⚠️ 주의사항

- 이 변경은 **씬 파일에 직접 적용**되었습니다
- Unity 에디터를 열 때 변경사항이 반영됩니다
- 만약 다른 씬(`howToPlay.unity` 등)에도 wolf가 있다면, 해당 씬에서도 별도로 비활성화해야 합니다
