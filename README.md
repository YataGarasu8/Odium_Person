# Odium_Person
플레이어 UI rngus

1.UI 설명
-왼쪽부터 캐릭터 선택, UI 선택, 캐릭터 스프라이트, UI이다.
-캐릭터 선택으로 캐릭터 변경 가능, 변경시 캐릭터 스프라이트가 변경된다.
-UI 선택으로 캐릭터 설명, 능력치, 인벤토리로 이동 가능하다.
-인벤토리에서는 아이템 장비 가능, 장비 시 스테이터스에 반영. 소모품도 있지만 사용만 되고 별 다른 효과는 없다.
-캐릭터의 레벨에 따라 능력치 상승, 캐릭터 별 초기, 최대 능력치가 차이 난다.

2.메서드 호출
-UI 아래의 버튼 시험용. 장비품(나무방망이), 소모품(레드 포션), 골드를 획득 가능하다

3.아쉬운 점
-인덱스와 리스트.카운트가 어긋나 일부 장비 삭제시 에러가 발생한다.
-본래라면 가챠 시스템을 구현하고 싶었다. 캐릭터, 장비 등을 가챠에서 획득해 인벤토리에 넣고 싶었다.
-객체지향하여 세션 때 배웠던 TemplateMethod 같은 걸 적용하고 싶었지만 만들다 보니 싱클톤만 주구장창 이용해 먹었다.
-리드미에 사진을 넣고 싶었는 방법을 잘 모르겠다.