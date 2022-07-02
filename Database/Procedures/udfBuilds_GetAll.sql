DROP FUNCTION builds_getall();

create or replace FUNCTION Builds_GetAll()
    returns TABLE (
    build_id int,
    title text,
    archived bool
                  )
language plpgsql
as $$
begin
    RETURN QUERY
    SELECT builds.build_id, builds.title, builds.archived
    FROM builds;
end;$$;